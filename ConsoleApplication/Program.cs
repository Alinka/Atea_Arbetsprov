using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WebReference.WebSiteService service = new WebReference.WebSiteService();
            string msg;
            DateTime date = new DateTime();
            if (args.Length > 0)
            {
                msg = String.Concat(args, ' ');
                date = DateTime.Now;
                Console.WriteLine(date);
                Console.WriteLine(service.SendMessage(date, msg));
                return;
            }
            
            //Loop untill empty message is recieved
            while (1 == 1)
            {
                Console.WriteLine("Type Message (Press 'Enter' to close the application):");
                msg = Console.ReadLine();
                if (String.IsNullOrEmpty(msg)) return;
                date = DateTime.Now;
                Console.WriteLine(service.SendMessage(date, msg));
            }
        }
    }
}
