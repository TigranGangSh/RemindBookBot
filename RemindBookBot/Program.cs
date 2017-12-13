using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;


namespace RemindBookBot
{
    class Program
    {
        static void Main(string[] args)
        {
            RemindBookBotClient remindbot = new RemindBookBotClient();  //объявляем нового бота
            remindbot.testApi(); //тестим связь
            if (RemindBookBotClient.ApiCheck == 0) //если связь пашет(ApiCheck == 0) - пишет в консоль "здарова" и начинает работу
            {
                Console.WriteLine("RemindBook bot is running!");
                RemindBookBotClient.ReceiveMessage();               //начинает принимать сообщения
                Console.ReadLine();                 
            }
            else
            {
                Console.WriteLine("Something went wrong, bot doesn't work!");
                Console.ReadLine();
            }
        }
    }
    class RemindBookBotClient
    {
        private string token = "478223056:AAEV4aT7xSLBdWXrccEEkMDCdYRH_RzkwLw";
        static Telegram.Bot.TelegramBotClient Bot;
        public static int ApiCheck = 0;
        public async void testApi()         //метод проверки связи данного бота по нашему токену
        {
            try
            {
                Bot = new Telegram.Bot.TelegramBotClient(token);
                var me = await Bot.GetMeAsync();
                ApiCheck = 0;
                //Thread newThread = new Thread(RemindBookBotClient.ReceiveMessage);
               //newThread.Start();
            }
            catch (Exception ex)
            {
                ApiCheck = 1;
            }
        }
        public static async void ReceiveMessage()
        {
            int checkname = 0;
            var lastMessageId = 0;
            while (true)
            {
                var messages = await Bot.GetUpdatesAsync();
                if (messages.Length > 0)
                {
                    var last = messages[messages.Length - 1];
                    if (lastMessageId != last.Id)
                    {
                        lastMessageId = last.Id;
                        Console.WriteLine(last.Message.Text);
                        switch (last.Message.Text.ToLower().Trim())
                        {
                            case "/start":                            
                            case "hi":
                            case "hello":
                                {
                                    
                                    Console.WriteLine("Получено сообщение!");
                                    await Bot.SendTextMessageAsync(last.Message.From.Id, BotAnswers.SendFirstMessage());
                                    break;
                                }
                           case "/info":
                                {
                                    
                                    await Bot.SendTextMessageAsync(last.Message.From.Id, BotAnswers.CommandsInfo());
                                    break;
                                }
                            case "/createnote":
                                {
                                    await Bot.SendTextMessageAsync(last.Message.From.Id, BotAnswers.InsertNoteName());
                                    break;
                                }
                        }
                            /*if (checkname == 0 && last.Message.Text.Contains("/start"))
                            {
                               await Bot.SendTextMessageAsync(last.Message.From.Id, "Hello! How can I call you?");
                               checkname = 1;
                            }
                            if (checkname == 1)
                            {
                                await Bot.SendTextMessageAsync(last.Message.From.Id, "Nice to meet you, {0}! My name is RemindBookBot.",);
                            }*/
                        }
                }
                if (checkname == 0)
                {
                    Thread.Sleep(200);
                }
                }
        }
    } 
}