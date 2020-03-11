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
            client.SendTextMessageAsync(e.Message.Chat.Id, "в разработке");
        }
    }
}
