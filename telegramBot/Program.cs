using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OpenWeatherMap;

namespace telegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot tBot = new Bot();
            tBot.startBot();
        }
    }
}
