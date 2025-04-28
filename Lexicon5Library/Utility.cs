using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon5Library
{
    public static class Utility
    {
        public static void ErrorMessage(this string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Environment.NewLine}ERROR:{Environment.NewLine}{message}");
            Console.ResetColor();
        }
    }
}
