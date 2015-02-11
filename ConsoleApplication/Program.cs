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
            DateTime timeStamp = new DateTime();

            Console.WriteLine("Type Message:");

            msg = Console.ReadLine();
            timeStamp = DateTime.Now;

            Console.WriteLine(service.WriteInDb(timeStamp, msg));

           
            
            Console.ReadLine();
        }
    }
}
