using Lexicon5Library.Json;
using Lexicon5Library.Library;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Members;

public class Admin : User
{
    public Admin(string email, string password, string name, string surName) : base(email, password, name, surName)
    {
    }

    internal static void RemoveBook(List<Book> books)
    {
        PrintList(books);
        Console.Write("Write ISBN of book: ");
        bool success = long.TryParse(Console.ReadLine(), out long ISBN);
        var removedBook = books.Find(book => book.Isbn == ISBN);
        Console.WriteLine();

        if (success & removedBook != null)
        {
            string deleteInput = InputString($"Are you sure you want to delete this book: " +
            $"{removedBook!.Title}, {removedBook.Author}{Environment.NewLine}" +
            $"Type \"delete\" to delete. Otherwise just hit enter.");

            if (deleteInput.ToLower() == "delete")
            {
                books.Remove(removedBook);
                Console.WriteLine($"Book {removedBook.Title} has been removed.");
                JsonHandler.JsonSaveGeneric(books, JsonHandler.jsonFilePath);
            }
            else
                Console.WriteLine("The book was not removed.");
        }
        else if (books.Count == 0)
            Console.WriteLine("The library is empty.");
        else
            Console.WriteLine("The book you want to remove does not exist.");

        Console.WriteLine();
    }
    public static void AddBook(List<Book> books)
    {
        string title = InputString("Title: ");
        string author = InputString("Author: ");
        Console.Write($"ISBN: ");
        _ = long.TryParse(Console.ReadLine(), out long isbn);
        Console.Write($"Category: {Environment.NewLine}");

        foreach (var c in Enum.GetValues<BookCategory>())
        {
            Console.WriteLine($"{(int)c + 1}.{c}");
        }

        _ = int.TryParse(Console.ReadLine(), out int categoryInt);
        BookCategory category = (BookCategory)categoryInt - 1;

        try
        {
            Book.ValidateInput(title, author, isbn, category, books);
            Book book = new(title, author, isbn, category);
            Console.WriteLine($"Book {title} created!");
            books.Add(book);
            JsonHandler.JsonSaveGeneric(books, JsonHandler.jsonFilePath);
        }
        catch (ArgumentException e)
        {
            e.Message.ErrorMessage();
        }
    }

}
