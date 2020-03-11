using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeleBot
{
    class Program
    {
        static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient("1030848716:AAGfvtCqc0bL6HV9y_2ddXsRi96GkKnekD0");
            client.OnMessage += getMsg;
            client.StartReceiving();
            Console.Read();
        }

        private static void getMsg(object sender, MessageEventArgs e)
        {
            if (e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return;

            Console.WriteLine($"Msg from {e.Message.Chat.Id}");
            switch (e.Message.Text.ToLower())
            {
                case "hello":
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Welocome to my chat");
                    break;
                case "привет":
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Добро пожаловать в чате");
                    break;
                case "салам":
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Валейкума!");
                    break;
                case "date":
                    client.SendTextMessageAsync(e.Message.Chat.Id, DateTime.Now.ToShortDateString());
                    break;
                case "time":
                    client.SendTextMessageAsync(e.Message.Chat.Id, DateTime.Now.ToShortTimeString());
                    break;
                case "id":
                    client.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Chat.Id.ToString());
                    break;
                case "btns":
                    var markup = new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton("Привет"),
                        new KeyboardButton("Hello"),
                        new KeyboardButton("Салам")
                    });
                    markup.OneTimeKeyboard = true;
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Choose lang", replyMarkup: markup);
                    break;
                default:
                    break;
            }

        }
    }
}
