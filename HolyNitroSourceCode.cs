using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

/*
 * Nitro Generator 
 * ----
 * ----
 * Made By TTheHolyOne
*/

namespace NitroGenerator
{
    class Program
    {
        static Random random = new Random();
        public static string generategift(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            Console.Title = "Holy Nitro - Welcome";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(@"

'##::::'##::'#######::'##:::::::'##:::'##::::'##::: ##:'####:'########:'########:::'#######::
 ##:::: ##:'##.... ##: ##:::::::. ##:'##::::: ###:: ##:. ##::... ##..:: ##.... ##:'##.... ##:
 ##:::: ##: ##:::: ##: ##::::::::. ####:::::: ####: ##:: ##::::: ##:::: ##:::: ##: ##:::: ##:
 #########: ##:::: ##: ##:::::::::. ##::::::: ## ## ##:: ##::::: ##:::: ########:: ##:::: ##:
 ##.... ##: ##:::: ##: ##:::::::::: ##::::::: ##. ####:: ##::::: ##:::: ##.. ##::: ##:::: ##:
 ##:::: ##: ##:::: ##: ##:::::::::: ##::::::: ##:. ###:: ##::::: ##:::: ##::. ##:: ##:::: ##:
 ##:::: ##:. #######:: ########:::: ##::::::: ##::. ##:'####:::: ##:::: ##:::. ##:. #######::
..:::::..:::.......:::........:::::..::::::::..::::..::....:::::..:::::..:::::..:::.......:::

");
            ConsoleColors();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Made By TTheHolyOne#1642\n\nPlease wait..");

            Thread.Sleep(5000);
            Console.Title = "Holy Nitro - Activated";
            Console.Clear();

            ConsoleColors();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Welcome... Enjoy\n");

            ConsoleColors();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" How much time between code? (");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1000 = 1s");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("): ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int delay = Convert.ToInt32(Console.ReadLine());


            ConsoleColors();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" How many codes would you like to generate: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            List<string> gifts = new List<string>();


            int asd = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < asd; i++)
            {
                gifts.Add(generategift(16));
            }

            foreach (string gift in gifts)
            {

                try
                {
                    //string[] proxys = File.ReadAllLines("proxy.txt");
                    Random proxySelect = new Random();
                    WebClient wc = new WebClient();
                    //wc.Proxy = new WebProxy(proxys[proxySelect.Next(0,proxys.Length-1)]);
                    wc.Proxy = null;
                    string data = wc.DownloadString("https://discordapp.com/api/v6/entitlements/gift-codes/" + gift);
                    dynamic jo = JObject.Parse(data);
                    Console.WriteLine($"Working code: {gift}", Console.ForegroundColor = ConsoleColor.Green);
                    Console.WriteLine("Please keep this code safe :D");
                    Console.ReadLine();
                }
                catch (WebException esx)
                {
                    if (esx.Response != null)
                    {
                        string esxK = new StreamReader(esx.Response.GetResponseStream()).ReadToEnd();
                        var res = JsonConvert.DeserializeObject<dynamic>(esxK);
                        if (esxK.ToLower().Contains("rate"))
                        {
                            Console.WriteLine("");
                            ConsoleColors();
                            Console.Write($" Rate Limited: {gift}", Console.ForegroundColor = ConsoleColor.DarkRed);
                            Console.WriteLine("");
                            ConsoleColors();
                            Console.Write(" Change your IP Address or use a proxy..", Console.ForegroundColor = ConsoleColor.DarkRed);
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("");
                            ConsoleColors();
                            Console.Write($" Not working code: {gift} | {res.message}", Console.ForegroundColor = ConsoleColor.Magenta);
                            Console.WriteLine("");
                        }
                    }
                }
                System.Threading.Thread.Sleep(delay);
            };
            ConsoleColors();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Done, Press enter to quit");
            Console.ReadLine();
        }
        static void ConsoleColors()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("CONSOLE");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
