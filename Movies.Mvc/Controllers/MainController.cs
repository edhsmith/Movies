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

            WebRequest req = WebRequest.CreateHttp("http://webjetapitest.azurewebsites.net/api/filmworld/movies");
            req.Headers.Add("x-access-token", "sjd1HfkjU83ksdsm3802k");
            string result = string.Empty;
           

            using(HttpWebResponse resp = (HttpWebResponse)req.GetResponse()){
                using(StreamReader sr = new StreamReader(resp.GetResponseStream())){
                    result = sr.ReadToEnd();
                 
                    sr.Close();
                }
                resp.Close();
            }

           
            return this.Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMovieDetail(string id){
            WebRequest req = WebRequest.CreateHttp("https://webjetapitest.azurewebsites.net/api/filmworld/movie/" + id);
            req.Headers.Add("x-access-token", "sjd1HfkjU83ksdsm3802k");
            req.Method = "GET";

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
            return this.Json(result,JsonRequestBehavior.AllowGet);
        }

       


    }
}
