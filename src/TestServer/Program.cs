using Microsoft.Owin.Hosting;
using System;

namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string address;
            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                address = string.Format("http://{0}/", args[0]);
            }
            else
            {
                address = Constants.DEFAULT_ADDR;
            }
            Console.WriteLine("Starting server at {0}\n", address);
            
            try
            {
                using (WebApp.Start<Startup>(url: address))
                {
                    Console.WriteLine("The server is up, press any key to quit...");
                    _ = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}\n\n{1}\n\nPress any key to quit...", e.Message, e.InnerException.ToString());
                _ = Console.ReadLine();
            }
        }
    }
}