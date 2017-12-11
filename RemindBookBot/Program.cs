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
            RemindBookBot girlBot = new RemindBookBot();
            girlBot.testApiAsync();
            Console.ReadLine();
        }
    }
    class RemindBookBot
    {
        private string token = "478223056:AAEV4aT7xSLBdWXrccEEkMDCdYRH_RzkwLw";
        static Telegram.Bot.TelegramBotClient Bot;
        public async void testApiAsync()
        {
            try
            {
                Bot = new Telegram.Bot.TelegramBotClient(token);
                var me = await Bot.GetMeAsync();
                Console.WriteLine("Hello my name is " + me.FirstName);
                Thread newThread = new Thread(RemindBookBot.ReceiveMessage);
                newThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hello my name is " + ex.Message);
            }
        }
        private static async void ReceiveMessage()
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
                            case "/info":
                            case "hi":
                            case "hello":
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