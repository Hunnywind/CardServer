using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Duel Manager Game Server");
            Console.WriteLine("ESC: Quit");

            Server server = new Server();

            try
            {
                server.Start();
                Console.WriteLine("Server start ok.");

                while(server.m_runLoop)
                {
                    if(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message.ToString());
            }
            finally
            {
                server.Dispose();
            }
        }
    }
}
