using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

namespace Proj.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public JsonResult Index()
        {
            List<Conditions> forecast = new List<Conditions>();
            forecast = GetForecast("Tel Aviv"); // 7 days forecast 
            List<string> sendList = new List<string>();
            sendList = makeStrings(forecast);
            return Json(sendList, JsonRequestBehavior.AllowGet);

        }
        private List<string> makeStrings(List<Conditions> conditions) // returns only today forecast
        {
            List<string> outList = new List<string>();
            outList.Add("Today");
            outList.Add(conditions[0].condition);
            outList.Add(conditions[0].tempC);

            return outList;
        }

        /// <summary>
        /// The function that gets the forecast for the next four days.
        /// </summary>
        /// <param name="location">City or ZIP code</param>
        /// <returns></returns>
        public static List<Conditions> GetForecast(string location)
        {
            List<Conditions> conditions = new List<Conditions>();

            XmlDocument xmlConditions = new XmlDocument();
            string path = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + location + "&mode=xml&units=metric&cnt=7&appid=bd82977b86bf27fb59a04b61b657fb6f";
            xmlConditions.Load(string.Format(path, location));
            double i = 0;
            foreach (XmlNode node in xmlConditions.SelectNodes("/weatherdata/forecast/time"))
            {
                Conditions condition = new Conditions();
                condition.City = xmlConditions.SelectSingleNode("/weatherdata/location/name").InnerText;
                condition.condition = node.SelectSingleNode("symbol").Attributes["name"].InnerText;
                condition.tempC = node.SelectSingleNode("temperature").Attributes["day"].InnerText;
                condition.dayOfWeek = DateTime.Today.AddDays(i).ToString();
                condition.dayOfWeek.Remove(10);
                i = i + 1;
                conditions.Add(condition);
            }
            return conditions;
        }
    }
    public class Conditions
    {
        public string City { get; set; }
        public string dayOfWeek { get; set; }
        public string condition { get; set; }
        public string tempC { get; set; }
        public string wind { get; set; }
    }
}