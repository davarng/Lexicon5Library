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

    public User(string email, string password, string name, string lastName)
    {
        Email = email;
        Password = password;
        Name = name;
        LastName = lastName;
        Role = UserRole.User;
    }

    internal static void SetBookStatus(List<Book> books)
    {
        PrintList(books);
        Console.Write("Write ISBN of book: ");
        bool success = long.TryParse(Console.ReadLine(), out long ISBN);
        var book = books.Find(book => book.Isbn == ISBN);

        if (success & book != null)
        {
            book!.IsAvailable = !book.IsAvailable;
            Console.WriteLine($"Book {book.Title} is now: {(book.IsAvailable ? "" : "not ")}available");
            JsonHandler.JsonSaveGeneric(books, JsonHandler.libraryFilePath);
        }
        else if (books.Count == 0)
            Console.WriteLine("No books in library.");
        else
            Console.WriteLine("The book you chose does not exist.");
    }

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
