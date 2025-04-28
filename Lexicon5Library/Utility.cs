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
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR:{Environment.NewLine}{message}");
            Console.ResetColor();
        }
    }
}
