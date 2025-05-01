using Lexicon5Library.Json;
using Lexicon5Library.Library;
namespace Lexicon5Library.Members;


public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }

    //Assigns the role to user by default.
    public User(string email, string password, string name, string lastName)
    {
        Email = email;
        Password = password;
        Name = name;
        LastName = lastName;
        Role = UserRole.User;
    }

    //Change the status of the book to available or not available.
    internal static void SetBookStatus(List<Book> books)
    {
        PrintList(books);
        Console.Write("Write ISBN of book: ");
        //Write ISBN of book to change status.
        bool success = long.TryParse(Console.ReadLine(), out long ISBN);
        var book = books.Find(book => book.Isbn == ISBN);

        //If the book exists
        if (success & book != null)
        {
            //Sets the status of the book to the opposite of what it is now And saves the list to the JSON file.
            book!.IsAvailable = !book.IsAvailable;
            Console.WriteLine($"Book {book.Title} is now: {(book.IsAvailable ? "" : "not ")}available");
            JsonHandler.JsonSaveGeneric(books, JsonHandler.libraryFilePath);
        }
        //If the book does not exist or the list is empty the user gets an error message.
        else if (books.Count == 0)
            Console.WriteLine("No books in library.");
        else
            Console.WriteLine("The book you chose does not exist.");
    }

    //Method to print the list of books. Sorts the list by title using Linq and prints it out.
    internal static void PrintList(List<Book> listOfBooks)
    {
        if (listOfBooks.Count > 0)
        {
            var sortedListOfBooks = listOfBooks.OrderBy(b => b.Title);
            foreach (var book in sortedListOfBooks)
            {
                Console.WriteLine($"{book}{Environment.NewLine}" +
                    $"---------------------------------");

            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The list is empty...");
        }
    }
}
