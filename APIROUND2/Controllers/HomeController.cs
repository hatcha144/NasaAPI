using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APIROUND2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Nasa()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=Kifm10zmCjgXhQboG8jEVEf2FaqvWZW4dXFsbtxY");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();

            JObject nasaJson = JObject.Parse(data);

            List<JToken> singlePost = nasaJson["photos"].ToList();

            ViewBag.img = singlePost[0]["img_src"];
            ViewBag.img2 = singlePost[1]["img_src"];
            ViewBag.img3 = singlePost[2]["img_src"];


            return View();

        }
    }
}