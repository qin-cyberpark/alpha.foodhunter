using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodHunterAlpha.Models;
using System.Linq;
using System.Data.Entity;
using FoodHunterAlpha.Models;
namespace FoodHunterAlpha.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            using(var db = new Entities())
            {
                var rest = Store.Get(34);

            }
        }
    }
}
