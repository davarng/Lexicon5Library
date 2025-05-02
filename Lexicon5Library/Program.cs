using Lexicon5Library.Json;
using Lexicon5Library.Library;
using Lexicon5Library.Members;
using static Lexicon5Library.Utility;
namespace Lexicon5Library;

internal class Program
{
    static void Main(string[] args)
    {
        //Declare two lists of books and users and calls the generic load JSON method on both lists.
        List<Book> books = [];
        List<User> users = [];
        JsonHandler.JsonLoadGeneric(ref books, JsonHandler.libraryFilePath);
        JsonHandler.JsonLoadGeneric(ref users, JsonHandler.userFilePath);

        string input;

        //Create a user object to store the logged in user.
        User? loggedInUser = null;

        while (true)
        {   
            //Runs the login screen method from the AccountService class.
            AccountService.UserLoginScreen(users, ref loggedInUser);
            
            //If the user is logged in they enter the main menu.
            while (loggedInUser != null)
            {
                //Work in progress admin options. Can currently be used by all users.
                //Prints and takes input for menu.
                input = InputString($"Write one of the options.{Environment.NewLine}" +
                    $"1. (ADMIN)Create book{Environment.NewLine}" +
                    $"2. List books{Environment.NewLine}" +
                    $"3. (ADMIN)Remove book{Environment.NewLine}" +
                    $"4. Search book{Environment.NewLine}" +
                    $"5. Change book availability{Environment.NewLine}" +
                    $"6. Log out{Environment.NewLine}");

                Console.Clear();

                switch (input)
                {
                    case "1":
                        //Admin add book method.
                        Admin.AddBook(books);
                        break;
                    case "2":
                        //User list books method.
                        User.PrintList(books);
                        break;
                    case "3":
                        //Admin remove book method.
                        Admin.RemoveBook(books);
                        break;
                    case "4":
                        //User search book method.
                        books.BookSearchSelection();
                        break;
                    case "5":
                        //User change book availability method.
                        User.SetBookStatus(books);
                        break;
                    case "6":
                        //User logs out.
                        loggedInUser = null;
                        break;
                    default:
                        //If the user input is not valid we print a message.
                        Console.WriteLine("Your input is not valid");
                        break;
                }
            }
        }
    }
}
