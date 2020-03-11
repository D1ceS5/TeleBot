using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Data.SQLite;
using System.IO;

namespace TeleBot
{
    class Program
    {

        static TelegramBotClient client;
        static string path = "botDB.sqlite";
        static void Main(string[] args)
        {
            if (!CheckExistDataBase(path))
                CreateDataBase(path);

            client = new TelegramBotClient("1030848716:AAGfvtCqc0bL6HV9y_2ddXsRi96GkKnekD0");
            client.OnMessage += getMsg;
            client.StartReceiving();


            Console.Read();
        }

        private static bool CheckExistDataBase(string path) => File.Exists(path);
        private static void CreateDataBase(string path)
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {path}"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Answer" +
                    "([id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[text] VARCHAR(255) NOT NULL);", connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Question" +
                    "([id] INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "[text] VARCHAR(255) NOT NULL," +
                    "[ID_ANSWER] INTEGER," +
                    "FOREIGN KEY(ID_ANSWER) REFERENCES Answer(ID));", connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void getMsg(object sender, MessageEventArgs e)
        {
            if (e.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return;
            client.SendTextMessageAsync(e.Message.Chat.Id, "в разработке");
        }
    }
}
