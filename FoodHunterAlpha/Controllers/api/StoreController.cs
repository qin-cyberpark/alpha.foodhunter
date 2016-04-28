﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodHunterAlpha.Models;

namespace FoodHunterAlpha.Controllers.api
{
    public class StoreController : ApiController
    {
        private Entities _db;
        public StoreController()
        {
            _db = new Entities();

        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        //[Route("api/store/{restId}/cate")]
        //public IList<MenuCategoryVM> GetCategories(long restId)
        //{
        //    return MenuCategoryVM.Get(_db, restId);
        //}

        [Route("api/{restId}/{cateId}")]
        public IList<Item> GetItems(int restId, int cateId)
        {
            var items =  Store.Get(restId).Categories.Where(x => x.Id == cateId).FirstOrDefault().Items;
            return items;
        }
    }
}
