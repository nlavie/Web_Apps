using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Proj.Controllers
{
    public class BannerController : Controller
    {
        // GET: Banner
        public JsonResult Index()
        {
            List<String> oList = new List<string>();
            List<String> sentList = new List<string>();
            List<String> minList = new List<string>();
            oList.Add("Be not afraid of going slowly. Be afraid only for standing still.");
            
            foreach(String s in oList)
            {
                sentList = stringSplitter(s);
            }
            
            sentList.Insert(0,sentList.Count.ToString());

            return Json(sentList, JsonRequestBehavior.AllowGet);
        }

        private List<String> stringSplitter(String text) // split the input in order to avoid out of bounds in Canvas
        {
            char[] delimiterChars = { ' ' };
            String[] words = text.Split(delimiterChars);
            
            for (int i = 0; i < words.Length-1; i=i+2)
            {
                words[i] = words[i] +" "+ words[i + 1];
                words[i + 1] = " "; 
            }
            return words.ToList<String>();
        }
    }
}

       
    

