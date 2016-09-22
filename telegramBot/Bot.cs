using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using Telegram.Bot.Types.ReplyMarkups;

using OpenWeatherMap;

namespace telegramBot
{
    class Bot
    {
        private readonly Telegram.Bot.TelegramBotClient botTelegram = new Telegram.Bot.TelegramBotClient("298122882:AAEDyDUVlymA1ossQx1nx12y_0XEGvj1mcw");
        public void test()
        {
            var me = botTelegram.GetMeAsync().Result;
            Console.WriteLine(me.FirstName);
            Console.WriteLine(me.Username);
        }
        public void startBot()
        {
            botTelegram.OnMessage += BotTelegram_OnMessage;
            botTelegram.StartReceiving();
            Console.ReadLine();
            botTelegram.StopReceiving();
        }
        private async void BotTelegram_OnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null || message.Type != MessageType.TextMessage) return;
            var client = new OpenWeatherMapClient("7574caa56a934eb3b27c54904c019e03");
            var weather = client.CurrentWeather.GetByName(message.Text);
            var temp = "\uD83C\uDF21";
            var degree = "\u00B0";
            //if (/*weather.Status == TaskStatus.WaitingForActivation*/ weather.Exception == null && !message.Text.StartsWith("/start"))
            //{
            //var clouds = Icons.getIcon(weather.Result.Clouds.Name);
            //await botTelegram.SendTextMessageAsync(message.Chat.Id,
            //    "City: " + weather.Result.City.Name + "\n" +
            //    "Temperature: " + temp + Math.Round((Convert.ToInt32(weather.Result.Temperature.Value) - 273.15), 1) + degree + "\n" +
            //    "Clouds: " + clouds + weather.Result.Clouds.Name + "\n" +
            //    "Pressure: " + Math.Round((Convert.ToDouble(weather.Result.Pressure.Value) / 1.333220000000039), 2));
            //}
            //else
            //{
            //    if (message.Text.StartsWith("/start"))
            //    {
            //        await botTelegram.SendTextMessageAsync(message.Chat.Id, "Hello to WeatherBot!!!");
            //    }
            //    else
            //    {
            //        await botTelegram.SendTextMessageAsync(message.Chat.Id, "Error city");
            //    }
            //}
            if (message.Text.StartsWith("/start"))
            {
                await botTelegram.SendTextMessageAsync(message.Chat.Id, "Hello to WeatherBot!!!");
            }
            else
            {
                try
                {
                    var clouds = Icons.getIcon(weather.Result.Clouds.Name);
                    await botTelegram.SendTextMessageAsync(message.Chat.Id,
                        "City: " + weather.Result.City.Name + "\n" +
                        "Temperature: " + temp + Math.Round((Convert.ToInt32(weather.Result.Temperature.Value) - 273.15), 1) + degree + "\n" +
                        "Clouds: " + clouds + weather.Result.Clouds.Name + "\n" +
                        "Pressure: " + Math.Round((Convert.ToDouble(weather.Result.Pressure.Value) / 1.333220000000039), 2));
                }
                catch (AggregateException)
                {
                    botTelegram.SendTextMessageAsync(message.Chat.Id, "Error city");
                   // await botTelegram.SendTextMessageAsync(message.Chat.Id, "Error city");
                }
            }

        }
    }
}
