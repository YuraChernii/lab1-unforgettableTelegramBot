/*
 My telegram bot reminder.
 Instruction:
 1.Find a bot called kry_kry_bot.
 2.Run the application(but before connect database(go to line 288)). 
 3.Enter something into the chat and voila.
*/
using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Passport;
using MySql.Data.MySqlClient;



namespace kry_kry_bot
{
    
    class Program
    {
        static int l = 0;
        //k = id in database
        static int k = 125;
        static int i = 0;
        static int j = 0;
        static int reminder_k = 0;
        static string data3 = "/set_reminder";
        static string data4;
        static TelegramBotClient Bot;


        static public void thank(to_do a,int id) { a.thank_you(id); }

        static void Main(string[] args)
        {
            BOT bot = new BOT();
            
            bot.buttons_start();
        }
        public abstract class to_do
        {
            public abstract void buttons_start(int id);
            public abstract void thank_you(int id);

        }

      public class BOT:to_do
        {
            override public void buttons_start(int id=0)
            {
                BOT bot2 = new BOT();
                //thank(bot2);
                Bot = new TelegramBotClient("1039097411:AAH8iozi-wYqioC14in_lMgxJ2E5O6ADo8o") { Timeout = TimeSpan.FromSeconds(10) };
                Bot.OnMessage += BotOnMessageReiceived;
                Bot.OnCallbackQuery += Bot_OnCallbackQueryReceived;
                var me = Bot.GetMeAsync().Result;
                
                Console.WriteLine($"Bot id: {me.Id}. Bot Name:{me.FirstName}");
                Bot.StartReceiving();
                Console.ReadLine();
                Bot.StopReceiving();
            }
            override public async void thank_you(int id)
            {
                string text3 =
@"Thank you for using my bot. Please click /start.";
                await Bot.SendTextMessageAsync(id, text3);
            }
            
            static private int day, hour, min;
            static private string data;
            static public string Data
            {
                get { return data; }
                set
                {
                        data = value;
                }
            }
            static public int Day
            {
                get { return day; }
                set {if(value>31)
                     day = 28; 
                    if (day == 0)
                        day = 1;
                    if(value <= 31 && day!=0)
                    day = value; 
                }       
            }
            static public int Hour
            {
                get { return hour; }
                set
                {
                    if (value > 24)
                        hour = 24;
                    else
                        hour = value;
                }
            }
            static public int Min
            {
                get { return min; }
                set
                {

                    if (hour== 24 )
                        min = 0;
                    else
                        min = value;
                }
            }
        }

        public class Reminder : to_do
        {
            override public async void thank_you(int id) {
                string text3 =
@"Thank you for using this function.";
                await Bot.SendTextMessageAsync(id, text3);
            }
            override public async void buttons_start(int id)
            {
                string text =
                     @"Список команд:
                    /start - запуск бота
                    /set_reminder - вивід меню";
                await Bot.SendTextMessageAsync(id, text);

            }
            public async void buttons_set_reminder(int id)
            {
                var inlineKeyboard1 = new InlineKeyboardMarkup(
                      new[] {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("0"),
                            InlineKeyboardButton.WithCallbackData("1"),
                            InlineKeyboardButton.WithCallbackData("2"),
                            InlineKeyboardButton.WithCallbackData("3"),
                            InlineKeyboardButton.WithCallbackData("4"),
                            InlineKeyboardButton.WithCallbackData("5"),
                            InlineKeyboardButton.WithCallbackData("6"),
                            InlineKeyboardButton.WithCallbackData("7")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("8"),
                            InlineKeyboardButton.WithCallbackData("9"),
                            InlineKeyboardButton.WithCallbackData("10"),
                            InlineKeyboardButton.WithCallbackData("11"),
                            InlineKeyboardButton.WithCallbackData("12"),
                            InlineKeyboardButton.WithCallbackData("13"),
                            InlineKeyboardButton.WithCallbackData("14"),
                            InlineKeyboardButton.WithCallbackData("15")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("16"),
                            InlineKeyboardButton.WithCallbackData("17"),
                            InlineKeyboardButton.WithCallbackData("18"),
                            InlineKeyboardButton.WithCallbackData("19"),
                            InlineKeyboardButton.WithCallbackData("20"),
                            InlineKeyboardButton.WithCallbackData("21"),
                            InlineKeyboardButton.WithCallbackData("22"),
                            InlineKeyboardButton.WithCallbackData("23")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("24"),
                            InlineKeyboardButton.WithCallbackData("25"),
                            InlineKeyboardButton.WithCallbackData("26"),
                            InlineKeyboardButton.WithCallbackData("27"),
                            InlineKeyboardButton.WithCallbackData("28"),
                            InlineKeyboardButton.WithCallbackData("29"),
                            InlineKeyboardButton.WithCallbackData("30"),
                            InlineKeyboardButton.WithCallbackData("31")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("32"),
                            InlineKeyboardButton.WithCallbackData("33"),
                            InlineKeyboardButton.WithCallbackData("34"),
                            InlineKeyboardButton.WithCallbackData("35"),
                            InlineKeyboardButton.WithCallbackData("36"),
                            InlineKeyboardButton.WithCallbackData("37"),
                            InlineKeyboardButton.WithCallbackData("38"),
                            InlineKeyboardButton.WithCallbackData("39")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("40"),
                            InlineKeyboardButton.WithCallbackData("41"),
                            InlineKeyboardButton.WithCallbackData("42"),
                            InlineKeyboardButton.WithCallbackData("43"),
                            InlineKeyboardButton.WithCallbackData("44"),
                            InlineKeyboardButton.WithCallbackData("45"),
                            InlineKeyboardButton.WithCallbackData("46"),
                            InlineKeyboardButton.WithCallbackData("47")
                        },
                          new[]
                        {
                            InlineKeyboardButton.WithCallbackData("48"),
                            InlineKeyboardButton.WithCallbackData("49"),
                            InlineKeyboardButton.WithCallbackData("50"),
                            InlineKeyboardButton.WithCallbackData("51"),
                            InlineKeyboardButton.WithCallbackData("52"),
                            InlineKeyboardButton.WithCallbackData("53"),
                            InlineKeyboardButton.WithCallbackData("54"),
                            InlineKeyboardButton.WithCallbackData("55"),
                        },
                           new[]
                        {
                            InlineKeyboardButton.WithCallbackData("56"),
                            InlineKeyboardButton.WithCallbackData("57"),
                            InlineKeyboardButton.WithCallbackData("58"),
                            InlineKeyboardButton.WithCallbackData("59")
                        }
                      }
                          );
                await Bot.SendTextMessageAsync(id, "Choose the date", replyMarkup: inlineKeyboard1);
            }
            
            public void time_to_remind(int id, int hour, int min,int id_for_data,string data2)
            {
                dataBase database = new dataBase();
                MySqlConnection conn = new MySqlConnection(database.buttons_start());
                conn.Open();
                
                MySqlCommand command = new MySqlCommand(database.insert(id_for_data, hour,min, data2), conn);
                
                command.ExecuteNonQuery();

                conn.Close();


                


                IntervalInHours(1,hour, min, id_for_data, 1, async
                      () =>
                {
                    MySqlConnection conn = new MySqlConnection(database.buttons_start());
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(database.select(id_for_data), conn);

                    string hour1, min1, data2;
                    
                MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        hour1 = reader[0].ToString();
                        min1 = reader[1].ToString();
                       data2 = reader[2].ToString();

                        Console.WriteLine(hour1);
                        Console.WriteLine(min1);


                        string text3 =
                               $"You asked me to remind me at {hour1}:{min1}: {data2}";

                        await Bot.SendTextMessageAsync(id, text3); 
                       
                    }
                    reader.Close();
                    MySqlCommand command2 = new MySqlCommand(database.delete(id_for_data), conn);
                    
                    command2.ExecuteNonQuery();
                    
                    conn.Close();
                    Reminder reminder = new Reminder();
                    thank(reminder, id);
                    
                });
            }

           
        }
        public class dataBase : BOT
        {
            public string buttons_start()
            {
                /*
                My table(new_table) in MYSQL consist of 4 part: the first column - id, the second - hour, 
                the third - min and the fourth is data.
                */
                string connStr = "server = 127.0.0.1; user = root; database = people; password = 11012002i;";
                return connStr;
            }
            public string insert(int id, int hour, int min,string data2)
            {
                string sql = $"INSERT INTO new_table (id,hour,min,data) VALUE ({id}, {hour}, {min}, '{data2}')";
                return sql;
            }
            public string delete(int id)
            {

                string sql =  $"DELETE FROM new_table WHERE id = {id}";
                return sql;
            }
            public string select(int id)
            {
                
                string sql = $"SELECT hour,min ,data FROM new_table WHERE id = {id}";
                return sql;
            }
        }
        public static void IntervalInHours(int day, int hour, int min, int k, double interval, Action task)
        {
            SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
        }

        private static void Bot_OnCallbackQueryReceived(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            
        }
        
        private static void BotOnMessageReiceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;
            if (l == 0)
            {
                BOT bot2 = new BOT();
                thank(bot2, message.From.Id);
                l++;
            }
            else { }
            if (message == null || message.Type != MessageType.Text)
                return;
        string name = $"{message.From.FirstName} {message.From.LastName}";
            if (j == 1) data3 = message.Text;
         Console.WriteLine($"{name} відправив повідомлення: {message.Text}");
            Reminder reminder = new Reminder();
            switch (message.Text)
            {
                case "/start":
                    
                    reminder.buttons_start(message.From.Id);
                    break;
               
                case "/set_reminder":

                    reminder.buttons_set_reminder(message.From.Id);
                    if (reminder_k == 0)
                    {
                        Bot.OnCallbackQuery += async (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) =>
                           {

                               if (i == 0)
                               {
                                   BOT.Day = int.Parse(ev.CallbackQuery.Data); Console.WriteLine("day" + BOT.Day);
                               }
                               if (i == 1)
                               {
                                   BOT.Hour = int.Parse(ev.CallbackQuery.Data); Console.WriteLine("hour" + BOT.Hour);
                               }
                               if (i == 2)
                               {
                                   BOT.Min = int.Parse(ev.CallbackQuery.Data); Console.WriteLine("min" + BOT.Min);
                                   string text2 =
                                 $"You chose the time: {BOT.Day}:{BOT.Hour}:{BOT.Min}.Now, send the data!!!";
                                   await Bot.SendTextMessageAsync(message.From.Id, text2);
                               // Thread.Sleep(10000);
                               BOT.Data = "/set_reminder";

                                   j++;
                                   while (BOT.Data == "/set_reminder")
                                   {
                                       if (data4 != data3)
                                           BOT.Data = data3;
                                   }
                                   j--;
                                   Console.WriteLine(BOT.Data);
                                   data4 = data3;
                               }

                               i++;
                               if (i == 3) i = 0;
                               if (i == 0)
                               {
                                   k++;
                                   reminder_k++;
                                   reminder.time_to_remind(message.From.Id, BOT.Hour, BOT.Min, k, BOT.Data);
                               }

                           };
                    }
                    
                    break;
                
                default:
                    break;
                    
                       

                }
                   
            
        }
    }
}
