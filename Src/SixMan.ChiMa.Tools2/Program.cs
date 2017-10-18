using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Tools2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter name:");
                string sourceName = Console.ReadLine();
                if( sourceName == "q")
                {
                    break;
                }
                string result = NameConvert.camelName(sourceName);
                Console.WriteLine(result);
            }
            while (true);

            Console.WriteLine("any key to exit");
            Console.ReadKey();
        }
    }
}
