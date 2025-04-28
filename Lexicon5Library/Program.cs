using Lexicon5Library.Json;
using Lexicon5Library.Library;
using System;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Xml;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lexicon5Library;

internal class Program
{
    //TODO
    //Admin panel/user panel
    //Add/remove category
    static void Main(string[] args)
    {
        List<Book> books = [];
        JsonHandler.JsonLoadLibrary(ref books);
        string input;

        while (true)
        {
            Console.WriteLine($"Write one of the options.{Environment.NewLine}" +
                $"1. Create book{Environment.NewLine}" +
                $"2. List books{Environment.NewLine}" +
                $"3. Remove book{Environment.NewLine}" +
                $"4. Search book{Environment.NewLine}" +
                $"5. add category{Environment.NewLine}" +
                $"6. remove category{Environment.NewLine}" +
                $"7. login{Environment.NewLine}" +
                $"8. admin area{Environment.NewLine}" +
                $"9. user area{Environment.NewLine}" +
                $"Q. Quit application.");

            input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    Person.AddBook(books);
                    break;
                case "2":
                    Person.PrintList(books);
                    break;
                case "3":
                    Person.RemoveBook(books);
                    break;
                case "4":
                    books.BookSearchSelection();
                    break;
                case "Q":
                case "q":
                    Console.WriteLine($"{Environment.NewLine}Closing application window...");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Your input is not valid");
                    break;
            }
        }
    }
}
