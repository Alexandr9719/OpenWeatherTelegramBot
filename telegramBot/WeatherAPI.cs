using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace telegramBot
{
    class WeatherAPI
    {
        private static readonly string wAPI = "7574caa56a934eb3b27c54904c019e03";
        private string City;
        public WeatherAPI(string city)
        {
            this.City = city;
            GetXml();
        }
        //private static string url = "http://api.openweathermap.org/data/2.5/weather?q=Simferopol&mode=xml&appid=" + wAPI;
        private void GetXml()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + City + "&units=metric&mode=xml&appid=" + wAPI;
            string temp = ""; string city = "";
            XDocument doc = XDocument.Load(url);
            foreach (XElement element in doc.Root.Elements())
            {
                switch (element.Name.ToString())
                {
                    case "temperature":
                        Console.WriteLine(element.Attribute("value").Value);
                        temp = element.Attribute("value").Value;
                        break;
                    case "city":
                        Console.WriteLine(element.Attribute("name").Value);
                        city = element.Attribute("name").Value;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
