using Lexicon5Library.Json;
using Lexicon5Library.Library;
using Lexicon5Library.Members;

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
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine($"Write one of the options.{Environment.NewLine}" +
                    $"1. (ADMIN)Create book{Environment.NewLine}" +
                    $"2. List books{Environment.NewLine}" +
                    $"3. (ADMIN)Remove book{Environment.NewLine}" +
                    $"4. Search book{Environment.NewLine}" +
                    $"5. Change book availability{Environment.NewLine}" +
                    $"6. Log out{Environment.NewLine}" +
                    $"Q. Quit application.");

                input = Console.ReadLine() ?? "";
                Console.Clear();

                switch (input)
                {
                    case "1":
                        Admin.AddBook(books);
                        break;
                    case "2":
                        User.PrintList(books);
                        break;
                    case "3":
                        Admin.RemoveBook(books);
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
}
