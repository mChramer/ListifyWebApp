using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace ListifyClient
{
    public class ListifyMenu
    {
        public RequestHandler request;
        public ListifyMenu(RequestHandler requestHandler)
        {
            request = requestHandler;

        }
        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("THIS IS THE CLIENT");
                Console.WriteLine("1. -> Get    | See list by id number");
                Console.WriteLine("2. -> Post   | Add list");
                Console.WriteLine("3. -> Put    | Update list");
                Console.WriteLine("4. -> Delete | Delete list");
                Console.WriteLine("5. -> Quit   | Quit the program");
                Console.WriteLine();
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "get":
                        request.Get();
                        break;
                    case "2":
                    case "post":
                        request.Post();
                        break;
                    case "3":
                    case "put":
                        request.Put();
                        break;
                    case "4":
                    case "delete":
                        request.Delete();
                        break;
                    case "5":
                    case "quit":
                        Environment.Exit(0);
                        break;


                }
            }
        }
    }
}
