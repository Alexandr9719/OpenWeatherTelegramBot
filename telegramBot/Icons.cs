using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegramBot
{
    public static class Icons
    {
        public static string getIcon(string icon)
        {
            var clouds = "";
            switch (icon)
            {
                case "clear sky":
                    clouds = "\u2600\uFE0F";
                    break;
                case "few clouds":
                    clouds = "\uD83C\uDF24";
                    break;
                case "scattered clouds":
                    clouds = "\u2601\uFE0F";
                    break;
                case "broken clouds":
                    clouds = "\u2601\uFE0F";
                    break;
                case "light rain":
                    clouds = "\uD83C\uDF26";
                    break;
                case "shower rain":
                    clouds = "\uD83C\uDF27";
                    break;
                case "rain":
                    clouds = "\uD83C\uDF27";
                    break;
                case "thunderstorm":
                    clouds = "\uD83C\uDF29";
                    break;
                case "snow":
                    clouds = "\uD83C\uDF28";
                    break;
                case "mist":
                    clouds = "\uD83C\uDF2B";
                    break;

                default:
                    break;
            }
            return clouds;
        }
    }
}
