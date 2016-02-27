using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

namespace Proj.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        // GET: Address
        public JsonResult Index(string location)
        {
            List<string> point = new List<string>();
            point = getPoint(location); // get point lat long 
            return Json(point, JsonRequestBehavior.AllowGet);

        }
        public static List<string> getPoint(string location)
        {
            List<string> point = new List<string>();
            XmlDocument xmlConditions = new XmlDocument();
            string path = "http://maps.google.com/maps/api/geocode/xml?address=" + location + "&sensor=false";
            xmlConditions.Load(string.Format(path, location));
            point.Add(xmlConditions.SelectSingleNode("/GeocodeResponse/result/geometry/location/lat").InnerText);
            point.Add(xmlConditions.SelectSingleNode("/GeocodeResponse/result/geometry/location/lng").InnerText);
            return point;
        }
    }
}