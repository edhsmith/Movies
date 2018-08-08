using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json.Linq;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Mvc.Controllers
{
    public class MainController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMovies(){
            string url = "http://webjetapitest.azurewebsites.net/api/filmworld/movies";
            string data = Get(url);
           
            return this.Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMovieDetail(string id){
            string url = "https://webjetapitest.azurewebsites.net/api/filmworld/movie/" + id;
            string data = Get(url);

            return this.Json(data,JsonRequestBehavior.AllowGet);
        }

       
        private string Get(string url)
        {
            WebRequest req = WebRequest.CreateHttp(url);
            req.Headers.Add("x-access-token", "sjd1HfkjU83ksdsm3802k");
            req.Method = "GET";
            req.Timeout = 5000;
            string result = string.Empty;
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
                resp.Close();
            }

            return result;
        }

    }
}
