using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Web.Controllers
{
    public class MainController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
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
            return this.Json(result);
        }

        public JsonResult GetMovieDetail(string id){
            WebRequest req = WebRequest.CreateHttp("https://webjetapitest.azurewebsites.net/api/filmworld/movie/" + id);
            req.Headers.Add("x-access-token", "sjd1HfkjU83ksdsm3802k");
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
            return this.Json(result);
        }


    }
}
