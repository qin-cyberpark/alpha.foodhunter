using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHunterAlpha.Printer
{
    public class PrintPaperRequest : BaseRequest
    {
        public PrintPaperRequest(string accessKey, string printerId, int userId, string content) : base(accessKey, "printpaper")
        {
            Parameters.Add(new KeyValuePair<string, string>("memobirdID", printerId));
            Parameters.Add(new KeyValuePair<string, string>("printcontent", content));
            //Parameters.Add(new KeyValuePair<string, string>("userID", userId.ToString()));
        }
    }

    public class PrintPaperResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "result")]
        private int _result { get; set; }

        [JsonProperty(PropertyName = "printcontentid")]
        public int PrintContentID { get; set; }

        [JsonProperty(PropertyName = "smartGuid")]
        public string SmartGuid { get; set; }

        public bool Printed
        {
            get
            {
                return _result == 1;
            }
        }
    }
}
