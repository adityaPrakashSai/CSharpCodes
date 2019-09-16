using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Driver for flipCache");
            LRUPolicy<string, string> policy = new LRUPolicy<string, string>();
            FlipCache<string, string> flipCache = new FlipCache<string, string>(2, policy);
            while (true)
            {
                Console.WriteLine("Choose option to perform cache operations: ");
                Console.WriteLine("1. Add to cache");
                Console.WriteLine("2. Search In Cache");
                Console.WriteLine("3. Get Hit Ratio");
                int.TryParse(Console.ReadLine(), out int option);
                if(option != 1 && option != 2 && option != 3)
                {
                    Console.WriteLine("Wrong Option. Try Again");
                }
                else if(option == 1)
                {
                    Console.WriteLine("Enter key value to store:key:value");
                    var entry = Console.ReadLine();
                    var keyValues = entry.Split(':');
                    if (keyValues.Length == 2)
                    {
                        flipCache.Put(keyValues[0], keyValues[1]);
                    }
                    else
                    {
                        Console.WriteLine("Enter key value to store:key:value");
                    }
                }
                
                else if(option == 2)
                {
                    Console.WriteLine("Enter key to search in cache:");
                    var key = Console.ReadLine();
                    var value = flipCache.Get(key);
                    if (value != null)
                    {
                        Console.WriteLine("Value stored for key: " + key + " is : " + value);
                    }

                    else
                    {
                        Console.WriteLine("It is a miss in cache");
                    }
                }

                else if(option == 3)
                {
                    Console.WriteLine("The hit ratio for flip-cache is:" + flipCache.GetHitRatio());
                }
            }
            
        }
    }
}
