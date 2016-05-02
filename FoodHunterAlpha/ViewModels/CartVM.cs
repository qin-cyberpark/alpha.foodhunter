using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace FoodHunterAlpha.ViewModels
{
    public class CartVM
    {
        [JsonProperty(PropertyName = "itms")]
        public IList<CartItemVM> Items { get; set; }
    }
    public class CartItemVM
    {
        [JsonProperty(PropertyName ="i")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "q")]
        public int Quantity { get; set; }
    }
}