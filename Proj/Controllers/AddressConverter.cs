using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Proj.Controllers
{
    public class AddressConverter
    {
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