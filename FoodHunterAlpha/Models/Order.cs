using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha.Models
{
    public class Order
    {
        public enum OrderType
        {
            DineIn, Pickup
        }
        public int Id { get; set; }
        public OrderType Type { get; set; }
        public string CustomerId { get; set; }
        public Restaurant Store { get; set; }
        public IList<Item> Items { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public int TableNumber { get; set; }
        public DateTime PickupTime { get; set; } 
        public bool HasProcessed { get; set; }

        //static
        private static SortedList<int, Order> _orders = new SortedList<int, Order>();
        private static object _locker = new object();

        public static int GetNextOrderId()
        {
            lock (_locker)
            {
                if (_orders.Count == 0)
                {
                    return 1000;
                }
                return _orders.Keys.Max() + 1;
            }
        }

        public static void Add(Order order)
        {
            _orders.Add(order.Id, order);
            Clear();
        }

        public static Order GetOrder(int orderId)
        {
            if (_orders.ContainsKey(orderId))
            {
                return _orders[orderId];
            }

            return null;
        }

        public static IList<Order> GetOrder()
        {
            return _orders.Values.OrderByDescending(x=>x.OrderTime).ToList();
        }

        private static void Clear()
        {
            var len = _orders.Count;
            for (int i = 0; i < len - 10; i++)
            {
                _orders.RemoveAt(0);
            }
        }
    }
}