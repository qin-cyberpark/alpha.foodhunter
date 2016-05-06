using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodHunterAlpha.Models;
using System.Linq;
using System.Data.Entity;
using FoodHunterAlpha.Models;
using System.Drawing;
using FoodHunterAlpha.Printer;
using System.IO;
using System.Drawing.Imaging;

namespace FoodHunterAlpha.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Order o = new Order();
            o.Id = "0013201605030001";
            o.Type = Order.OrderType.Pickup;
            o.TableNumber = 19;
            o.OrderTime = DateTime.Now;
            o.PickupTime = DateTime.Now.AddMinutes(45);

            o.Items.Add(new OrderItem()
            {
                Item = new Item(new menu_item{item_desc = "Cafe Latte",item_price = 3.5M}),
                Quantity = 2
            });

            o.Items.Add(new OrderItem()
            {
                Item = new Item(new menu_item { item_desc = "Cappuccino", item_price = 3.6M }),
                Quantity = 3
            });

            o.Items.Add(new OrderItem()
            {
                Item = new Item(new menu_item { item_desc = "Short Black", item_price = 3M }),
                Quantity = 1
            });

            Receipt r = new Receipt(o);

            var c = new MemoBirdClient("87810a141cd74d1ca3a6511ab9ca8400");

            var ra = c.Print("67bfaa0f72c03202", 48952, r.Image);
            Assert.IsTrue(ra.Succeeded);
        }
    }
}
