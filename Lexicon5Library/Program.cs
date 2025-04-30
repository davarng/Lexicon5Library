using Lexicon5Library.Json;
using Lexicon5Library.Library;

namespace Lexicon5Library;

internal class Program
{
    static void Main(string[] args)
    {
        List<Book> books = [];
        JsonHandler.JsonLoadGeneric(ref books, JsonHandler.jsonFilePath);
        string input;

        while (true)
        {
            Console.WriteLine($"Write one of the options.{Environment.NewLine}" +
                $"1. Create book{Environment.NewLine}" +
                $"2. List books{Environment.NewLine}" +
                $"3. Remove book{Environment.NewLine}" +
                $"4. Search book{Environment.NewLine}" +
                $"5. Change book availability{Environment.NewLine}" +
                $"Q. Quit application.");

            input = Console.ReadLine() ?? "";
            Console.Clear();

            switch (input)
            {
                case "1":
                    User.AddBook(books);
                    break;
                case "2":
                    User.PrintList(books);
                    break;
                case "3":
                    User.RemoveBook(books);
                    break;
                case "4":
                    books.BookSearchSelection();
                    break;
                case "5":
                    User.SetBookStatus(books);
                    break;
                case "Q":
                case "q":
                    Console.WriteLine($"{Environment.NewLine}Closing application window...");
                    return;
                default:
                    Console.WriteLine("Your input is not valid");
                    break;
            }
            Console.WriteLine();
        }
    }
}
