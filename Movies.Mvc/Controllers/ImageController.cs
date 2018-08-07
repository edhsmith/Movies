using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Movies.Mvc.Controllers
{
    public class ImageController : ApiController
    {
        
        public HttpResponseMessage Get(string path)
        {
            byte[] buffer = null;

            WebRequest req = WebRequest.CreateHttp(path);
            using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Stream s = res.GetResponseStream())
                    {
                        s.CopyTo(ms);
                        ms.Position = 0;
                        buffer = ms.ToArray();
                    }
                    ms.Close();
                }
                res.Close();
            }
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(buffer);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");

            return result;

        }
    }
}
