using Lexicon5Library.Json;
using Lexicon5Library.Library;
using System.Security.Cryptography;
using static Lexicon5Library.Utility;
namespace Lexicon5Library.Members;


public class User
{
    private string Email { get; set; }
    private string Password { get; set; }
    private string Name { get; set; }
    private string LastName { get; set; }

    public User(string email, string password, string name, string lastName)
    {
        Email = email;
        Password = password;
        Name = name;
        LastName = lastName;
    }

    public static void SignUp()
    {
        string email = InputString("Email: ");
        string firstName = InputString("First name: ");
        string lastName = InputString("Last name: ");
        string password = InputString("Password(min 10 chars): ");
        List<User> users = new List<User>();

        try
        {
            //User.ValidateInput(title, author, isbn, category, books);
            User user = new(email, password, firstName, lastName);
            Console.WriteLine($"Account created!");
            users.Add(user);
            JsonHandler.JsonSaveGeneric(users, JsonHandler.jsonFilePath);
        }
        catch (ArgumentException e)
        {
            e.Message.ErrorMessage();
        }
    }

    private static string HashAndSaltPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        //disposed
        using var passwordHasher = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

        byte[] hash = passwordHasher.GetBytes(32);

        string hashAndSalt = Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

        return hashAndSalt;
    }



    //List book => book
    internal static void SetBookStatus(List<Book> books)
    {
        HashAndSaltPassword("s");
        PrintList(books);
        Console.Write("Write ISBN of book: ");
        bool success = long.TryParse(Console.ReadLine(), out long ISBN);
        var book = books.Find(book => book.Isbn == ISBN);

        if (success & book != null)
        {
            book!.IsAvailable = !book.IsAvailable;
            Console.WriteLine($"Book {book.Title} is now: {(book.IsAvailable ? "" : "not ")}available");
            JsonHandler.JsonSaveGeneric(books, JsonHandler.jsonFilePath);
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
