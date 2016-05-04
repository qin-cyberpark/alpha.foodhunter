using FoodHunterAlpha.Printer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha.Models
{
    public class OrderItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
    public class Order
    {
        public enum OrderType
        {
            DineIn, Pickup
        }
        public string Id { get; set; }
        public int SerialNo { get; set; }
        public OrderType Type { get; set; }
        public string CustomerId { get; set; }
        public Restaurant Store { get; set; }
        public IList<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public int TableNumber { get; set; }
        public DateTime PickupTime { get; set; }
        public bool HasCompleted { get; set; }
        public string PrintContentId { get; set; }
        public DateTime PrintTime
        {
            get
            {
                if (Type == OrderType.DineIn)
                {
                    return OrderTime;
                }
                else
                {
                    return PickupTime.AddMinutes(-10);
                }
            }
        }

        public decimal Total
        {
            get
            {
                decimal ttl = 0;
                foreach (var item in Items)
                {
                    ttl += item.Item.Price * item.Quantity;
                }

                return ttl;
            }
        }

        public decimal GST
        {
            get
            {
                return Total / 1.15M * 0.15M;
            }
        }

        //static
        private static SortedList<string, Order> _orders = new SortedList<string, Order>();
        private static object _locker = new object();

        public static int GetNextOrderSerialNo(int storeId)
        {
            lock (_locker)
            {
                int currSn = _orders.Values.OrderByDescending(x => x.OrderTime)
                            .FirstOrDefault(x => x.OrderTime.Date == DateTime.Today)?.SerialNo ?? 0;
                return ++currSn;
            }
        }

        public static void Add(Order order)
        {
            _orders.Add(order.Id, order);
            Clear();
        }

        public static Order GetOrder(string id)
        {
            if (_orders.ContainsKey(id))
            {
                return _orders[id];
            }

            return null;
        }

        public static bool CompleteOrder(string id)
        {
            if (_orders.ContainsKey(id))
            {
                _orders[id].HasCompleted = true;
                return true;
            }

            return false;
        }
        public static IList<Order> GetOrder()
        {
            return _orders.Values.OrderBy(x => x.PrintTime).ToArray();
        }

        public static IList<string> GetOrderIds(int restId, bool hasCompleted = false)
        {
            return _orders.Values.Where(x => x.HasCompleted == hasCompleted)
                .OrderBy(x => x.PrintTime).Select(x => x.Id).ToList();
        }

        private static void Clear()
        {
            var len = _orders.Count;
            for (int i = 0; i < len - 50; i++)
            {
                _orders.RemoveAt(0);
            }
        }
    }
}