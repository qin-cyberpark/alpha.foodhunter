using FoodHunterAlpha.Models;
using FoodHunterAlpha.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha.Models
{
    public class Restaurant
    {
        private restaurant _data;
        public Restaurant(restaurant rest)
        {
            _data = rest;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameId { get { return Name.ToLower().Replace(" ", "-"); } }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IList<Category> Categories { get; set; }
        public string PrinterAddress { get; set; } = "67bfaa0f72c03202";
        public int PrinterUserId { get; set; } = 48952;
        public MemoBirdClient PrintClient { get; set; }

        public Restaurant ShallowCopy()
        {
            return (Restaurant)this.MemberwiseClone();
        }

        public static Restaurant Get(Entities db, long restId)
        {
            //load Restaurant
            var restData = db.restaurants.Where(x => x.rest_id == restId).FirstOrDefault();
            if (restData == null)
            {
                return null;
            }

            var rest = new Restaurant(restData);

            //load category
            rest.Categories = new List<Category>();
            db.menu_category.Where(x => x.rest_id == restId).OrderBy(x => x.cate_seq_no).ToList().ForEach(x =>
            {
                rest.Categories.Add(new Category(x) { Restaurant = rest });
            });

            //load item
            foreach (var cate in rest.Categories)
            {
                cate.Items = new List<Item>();
                db.menu_item.Where(x => x.rest_id == restId && x.cate_id == cate.Id).ToList().ForEach(x =>
                {
                    cate.Items.Add(new Item(x) { Category = cate });
                });

                //load option
                foreach (var item in cate.Items)
                {
                    ItemOptionGroup optGrp = null;
                    var opts = db.menu_item_option.Where(x => x.rest_id == restId && x.item_id == item.Id)
                        .OrderBy(x => x.option_group_id).ToList();
                    foreach (var opt in opts)
                    {
                        if (optGrp == null || opt.option_group_id != optGrp.GroupId)
                        {
                            if (optGrp != null)
                            {
                                item.OptionGroups.Add(optGrp);
                            }

                            //new group
                            optGrp = new ItemOptionGroup()
                            {
                                GroupId = opt.option_group_id.Value,
                                ItemId = item.Id,
                                Item = item,
                                ItemOptions = new List<ItemOption>()
                            };
                        }

                        var nwOpt = new ItemOption(opt) { Item = item };
                        optGrp.ItemOptions.Add(nwOpt);
                    }

                    if (optGrp != null)
                    {
                        item.OptionGroups.Add(optGrp);
                    }
                }
            }


            return rest;
        }

        public long GetCategoryId(string nameId)
        {
            foreach (var cate in Categories)
            {
                if (cate.NameId.Equals(nameId))
                {
                    return cate.Id;
                }
            }

            return 0;
        }

        public bool PrintOrder(Order order)
        {
            //print order
            var rep = PrintClient.Print(PrinterAddress, PrinterUserId, new Receipt(order).Image);
            if(rep != null && rep.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

    public class Category
    {
        private menu_category _data;
        public long Id { get { return _data.cate_id; } }
        public string NameId { get { return Description.ToLower().Replace(" ", "-"); } }
        public string Description { get { return _data.cate_desc; } }
        public long RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public Category(menu_category cate)
        {
            _data = cate;
        }

        public IList<Item> Items { get; set; }

    }

    public class Item
    {
        private menu_item _data;
        public Item(menu_item item)
        {
            _data = item;
        }

        public long Id { get { return _data.item_id; } }
        public int CategoryId { get { return _data.cate_id; } }

        public string Description { get { return _data.item_desc; } }
        public string NameId { get { return Description.ToLower().Replace(" ", "-"); } }
        public string Code { get { return _data.item_code; } }
        public decimal Price { get { return _data.item_price.Value; } }
        public Category Category { get; set; }
        public IList<ItemOptionGroup> OptionGroups { get; set; } = new List<ItemOptionGroup>();
    }

    public class ItemOptionGroup
    {
        public int GroupId { get; set; }
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public IList<ItemOption> ItemOptions { get; set; }
    }
    public class ItemOption
    {
        private menu_item_option _data;
        public ItemOption(menu_item_option opt)
        {
            _data = opt;
        }

        public long Id { get { return _data.menu_item_option_id; } }
        public string Description { get { return _data.option_desc; } }
        public long ItemId { get { return _data.item_id.Value; } }
        public Item Item { get; set; }
        public int GroupId { get { return _data.option_group_id.Value; } }
        public decimal Diff { get { return _data.price_difference.Value; } }
        public bool IsDefault
        {
            get
            {
                return (_data.is_default_option ?? 0) == 1;
            }
        }

    }

    public class Store
    {
        public const int DefaultRestaurantId = 50;
        public const string DefaultCustomerId = "Demo";

        #region store info
        private static string[][] storeData = new string[][]{
            new string[]{"-35.732265348315","174.32157666442","Columbus Mitre 10 MEGA Whangarei"},
            new string[]{"-36.406447419768","174.6479690418","Columbus Mitre 10 MEGA Warkworth"},
            new string[]{"-36.7221948","174.7061665","Columbus Mitre 10 MEGA Albany"},
            new string[]{"-36.727954423482","174.7083272792","Columbus Coffee Albany"},
            new string[]{"-36.7447429","174.6970369","Columbus Coffee William Pickering Drive"},
            new string[]{"-36.776775265553","174.74099315211","Columbus Mitre 10 MEGA Glenfield"},
            new string[]{"-36.7840927","174.7539426","Columbus Coffee Shops Smales Farm"},
            new string[]{"-36.787647553823","174.77077567725","Columbus Coffee Shore City, Takapuna"},
            new string[]{"-36.8094514","174.6026197","Columbus Mitre 10 MEGA Westgate"},
            new string[]{"-36.844800368307","174.7539375424","Columbus Coffee Air NZ Building"},
            new string[]{"-36.8560988","174.6293448","Columbus Coffee Lincoln Road"},
            new string[]{"-36.8576613","174.761131","Columbus Coffee on Queen Street"},
            new string[]{"-36.861197415672","174.77792400318","Columbus Coffee Auckland Museum"},
            new string[]{"-36.8614244","174.7704525","Columbus Coffee Auckland Hospital"},
            new string[]{"-36.879696277854","174.85115603929","Columbus Coffee Glen Innes"},
            new string[]{"-36.882671521933","174.67934343862","Columbus Coffee Rosebank Road"},
            new string[]{"-36.882757258782","174.6328131662","Columbus Coffee Henderson"},
            new string[]{"-36.8913556","174.8343434","Columbus Mitre 10 MEGA Mt Wellington"},
            new string[]{"-36.8985768","174.8106349","Columbus Coffee Ellerslie"},
            new string[]{"-36.89919153058","174.9013358332","Columbus Coffee Pakuranga"},
            new string[]{"-36.933468065899","174.91289816812","Columbus Coffee Botany"},
            new string[]{"-36.9111547","174.6540645","Columbus Coffee Glen Eden"},
            new string[]{"-36.9121211","174.6877906","Columbus Mitre 10 MEGA New Lynn"},
            new string[]{"-36.9169002","174.8391792","Columbus Coffee Sylvia Park"},
            new string[]{"-36.924988","174.7854476","Columbus Coffee Onehunga"},
            new string[]{"-36.958548","174.9018807","Columbus Coffee Botany - Home Base"},
            new string[]{"-36.990807804792","174.87081170082","Manukau - Supa Centa"},
            new string[]{"-36.9948555","174.8735251","Columbus Mitre 10 MEGA Manukau"},
            new string[]{"-37.1997581","174.9042407","Columbus Coffee Pukekohe"},
            new string[]{"-37.210107500288","174.91619874844","Columbus Mitre 10 MEGA Pukekohe"},
            new string[]{"-37.692949167377","176.10934468584","Columbus Coffee Bethlehem, Tauranga"},
            new string[]{"-37.714749576161","176.14210015397","Gate Pa"},
            new string[]{"-37.746339428353","175.22959652586","Columbus Mitre 10 MEGA Hamilton"},
            new string[]{"-37.7835527","175.2791736","Columbus Coffee London St, Hamilton"},
            new string[]{"-37.8919021","175.4772344","Columbus Mitre 10 MEGA Cambridge"},
            new string[]{"-37.953896253513","176.96708142757","Whakatane - Hub"},
            new string[]{"-38.0067611","175.3388251","Columbus Mitre 10 MEGA Te Awamutu"},
            new string[]{"-38.1374698","176.2405349","Columbus Mitre 10 MEGA Rotorua"},
            new string[]{"-38.139952808494","176.24980777502","Columbus Coffee Rotorua"},
            new string[]{"-38.7038052682","176.11086670979","Columbus at Mitre 10 MEGA Taupo"},
            new string[]{"-39.0459346","174.1148946","Columbus Mitre 10 MEGA New Plymouth"},
            new string[]{"-39.0599333","174.0579187","Columbus Coffee St Aubyn Street"},
            new string[]{"-39.4967161","176.8847014","Columbus Mitre 10 MEGA Napier"},
            new string[]{"-39.6384333","176.8514846","Columbus Mitre 10 MEGA Hastings"},
            new string[]{"-40.349671054146","175.60827570073","Columbus Mitre 10 MEGA Palmerston North"},
            new string[]{"-40.3569345","175.6132375","Columbus Coffee Palmerston North"},
            new string[]{"-40.9063615","174.9983028","Columbus Mitre 10 MEGA Kapiti"},
            new string[]{"-40.9476841","175.6360451","Columbus Mitre 10 MEGA Masterton"},
            new string[]{"-41.1299903","174.8368826","Columbus Mitre 10 MEGA Porirua"},
            new string[]{"-41.208970910714","174.90769763181","Columbus Coffee Queensgate, Wellington"},
            new string[]{"-41.274819755727","173.28552113436","Columbus Coffee Nelson"},
            new string[]{"-41.2849233","174.776043","Columbus Coffee Featherston Street, Wellington"},
            new string[]{"-41.2984928031","173.23933099577","Columbus Mitre 10 MEGA Nelson"},
            new string[]{"-41.307121267734","174.77775514233","Columbus Coffee Newtown"},
            new string[]{"-41.3414777","173.1874767","Columbus Coffee Richmond"},
            new string[]{"-41.5280763","173.9644318","Columbus Mitre 10 MEGA Marlborough"},
            new string[]{"-42.459662857008","171.19566953495","Columbus Mitre 10 MEGA Greymouth"},
            new string[]{"-43.5300246","172.5980704","Columbus Coffee Riccarton - Westfield Mall"},
            new string[]{"-43.5354265","172.6432225","Columbus Coffee Tuam St, Christchurch"},
            new string[]{"-43.5430285","172.5295447","Columbus Mitre 10 MEGA Hornby"},
            new string[]{"-43.904801768742","171.74403534722","Columbus Coffee Ashburton"},
            new string[]{"-45.007963022142","168.74944108674","Columbus Mitre 10 MEGA Queenstown"},
            new string[]{"-45.8929489","170.5045885","Columbus Mitre 10 MEGA Dunedin"},
            new string[]{"-46.4130796","168.3626655","Columbus Mitre 10 MEGA Invercargill"}};
        #endregion

        private static SortedList<string, Restaurant> _storesByName;
        private static SortedList<long, Restaurant> _storesById;
        private static SortedList<long, Item> _itemsById;
        static Store()
        {
            InitStores();
        }



        private static void InitStores()
        {
            _storesByName = new SortedList<string, Restaurant>();
            _storesById = new SortedList<long, Restaurant>();
            _itemsById = new SortedList<long, Item>();

            using (var db = new Entities())
            {
                var rest = Restaurant.Get(db, DefaultRestaurantId);
                foreach (var cate in rest.Categories)
                {
                    foreach (var item in cate.Items)
                    {
                        _itemsById.Add(item.Id, item);
                    }
                }
                for (int idx = 0; idx < storeData.Length; idx++)
                {
                    var arr = storeData[idx];
                    var restCpy = rest.ShallowCopy();
                    restCpy.Id = idx;
                    restCpy.Name = arr[2];
                    restCpy.Latitude = double.Parse(arr[0]);
                    restCpy.Longitude = double.Parse(arr[1]);
                    foreach (var cate in restCpy.Categories)
                    {
                        cate.RestaurantId = restCpy.Id;
                        cate.Restaurant = restCpy;
                    }
                    restCpy.PrintClient = new MemoBirdClient(System.Configuration.ConfigurationManager.AppSettings["PrinterAccessKey"]);

                    _storesByName.Add(restCpy.NameId, restCpy);
                    _storesById.Add(idx, restCpy);
                }
            }
        }
        public static IList<Restaurant> Restaurants
        {
            get
            {
                if (_storesByName == null)
                {
                    InitStores();
                }

                return _storesByName.Values;
            }
        }
        public static Restaurant Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            if (_storesByName == null)
            {
                InitStores();
            }

            if (_storesByName.ContainsKey(name))
            {
                return _storesByName[name];
            }

            return null;
        }

        public static Restaurant Get(int idx)
        {
            if (_storesById == null)
            {
                InitStores();
            }

            if (_storesById.ContainsKey(idx))
            {
                return _storesById[idx];
            }

            return null;
        }

        public static Item GetItem(long id)
        {
            if (_itemsById == null)
            {
                InitStores();
            }

            if (_itemsById.ContainsKey(id))
            {
                return _itemsById[id];
            }

            return null;
        }
    }
}