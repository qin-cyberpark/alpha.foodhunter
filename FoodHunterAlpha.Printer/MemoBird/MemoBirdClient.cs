using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace FoodHunterAlpha.Printer
{
    public class MemoBirdClient
    {
        private string _accessKey;
        private HttpClient _client = new HttpClient();
        public MemoBirdClient(string accessKey)
        {
            _accessKey = accessKey;
        }

        private string Request(BaseRequest request)
        {
            using (HttpResponseMessage response = _client.PostAsync(request.RequestUrl,
                                                        new FormUrlEncodedContent(request.Parameters)).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }

        public PrintStatusResponse HasPrinted(int contentId)
        {
            var req = new PrintStatusRequest(_accessKey, contentId);
            var resJson = Request(req);
            return JsonConvert.DeserializeObject<PrintStatusResponse>(resJson);
        }

        public PrintPaperResponse Print(string printerId, int userId, string content)
        {
            var req = new PrintPaperRequest(_accessKey, printerId, userId, content);
            var resJson = Request(req);
            if (!string.IsNullOrEmpty(resJson))
            {
                return JsonConvert.DeserializeObject<PrintPaperResponse>(resJson);
            }

            return null;
        }

        public PrintPaperResponse Print(string printerId, int userId, Bitmap img)
        {
            img.RotateFlip(RotateFlipType.Rotate180FlipX);
            var bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            var newBitmap = new Bitmap(img.Width, img.Height, bmpData.Stride, PixelFormat.Format1bppIndexed, bmpData.Scan0);

            //img.Save(@"e:\temp\sample.bmp", ImageFormat.Bmp);
            //return null;
            using (var memoStrem = new MemoryStream())
            {
                newBitmap.Save(memoStrem, ImageFormat.Bmp);
                byte[] imageBytes = memoStrem.ToArray();

                //Convert byte[] to Base64 String
                string base64String = "P:" + Convert.ToBase64String(imageBytes);
                //string base64String = "T:YWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4eXphYmNkZWZnaGlqa2xtbm9wcXJzdHV2d3h5eg0KQUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVpBQkNERUZHSElKS0xNTk9QUVJTVFVWV1hZWg0KMTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkw";
                return Print(printerId, userId, base64String);
            }
        }
    }
}