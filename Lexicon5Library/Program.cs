using Lexicon5Library.Json;
using Lexicon5Library.Library;
using Lexicon5Library.Members;
using static Lexicon5Library.Utility;
namespace Lexicon5Library;

internal class Program
{
    static void Main(string[] args)
    {
        List<Book> books = [];
        List<User> users = [];
        JsonHandler.JsonLoadGeneric(ref books, JsonHandler.libraryFilePath);
        JsonHandler.JsonLoadGeneric(ref users, JsonHandler.userFilePath);

        string input;
        User? loggedInUser = null;

        while (true)
        {
            string accountInput = InputString($"1. Login{Environment.NewLine}" +
                $"2. Create account{Environment.NewLine}");

            switch (accountInput)
            {
                case "1":
                    //WIP
                    loggedInUser = AccountService.SignIn(users);
                    break;
                case "2":
                    AccountService.SignUp(users);
                    break;
                case "Q":
                case "q":
                    Console.WriteLine($"{Environment.NewLine}Closing application window...");
                    return;
            }

            while (loggedInUser != null)
            {
                Console.WriteLine($"Write one of the options.{Environment.NewLine}" +
                    $"1. (ADMIN)Create book{Environment.NewLine}" +
                    $"2. List books{Environment.NewLine}" +
                    $"3. (ADMIN)Remove book{Environment.NewLine}" +
                    $"4. Search book{Environment.NewLine}" +
                    $"5. Change book availability{Environment.NewLine}" +
                    $"6. Log out{Environment.NewLine}");

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
                    case "6":
                        loggedInUser = null;
                        break;
                    default:
                        Console.WriteLine("Your input is not valid");
                        break;
                }
            }
        }
    }
}
