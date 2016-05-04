using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha.Printer
{
    public class PrintStatusRequest : BaseRequest
    {
        public PrintStatusRequest(string accessKey, int printContentID) : base(accessKey, "getprintstatus")
        {
            Parameters.Add(new KeyValuePair<string, string>("printcontentid", printContentID.ToString()));
        }
    }

    public class PrintStatusResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "printflag")]
        private int _printFlag { get; set; }

        [JsonProperty(PropertyName = "printcontentid")]
        public int PrintContentID { get; set; }

        public bool Printed
        {
            get
            {
                return _printFlag == 1;
            }
        }
    }
}