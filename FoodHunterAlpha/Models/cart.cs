using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha.Models
{
    public class CartItem
    {
        public Item Item { get; set; }
        public ItemOption Option { get; set; }
        public int Amount { get; set;}
    }
    public class cart
    {
        //public IList<>
    }
}