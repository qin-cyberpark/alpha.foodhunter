using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace FoodHunterAlpha.Printer
{
    public class BaseRequest
    {
        private static string _domain = "http://open.memobird.cn/home/";

        protected BaseRequest(string accessKey, string mothed)
        {
            RequestUrl = _domain + mothed;
            Parameters = new List<KeyValuePair<string, string>>();
            Parameters.Add(new KeyValuePair<string, string>("ak", accessKey));
            Parameters.Add(new KeyValuePair<string, string>("timestamp", string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now)));
        }

        public string RequestUrl { get; }
        public IList<KeyValuePair<string, string>> Parameters { get; }
    }

    public class BaseResponse
    {
        [JsonProperty(PropertyName = "showapi_res_code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "showapi_res_error")]
        public string Error { get; set; }

        public bool Succeeded
        {
            get
            {
                return Code == 1;
            }
        }
    }
}