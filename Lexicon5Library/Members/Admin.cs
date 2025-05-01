using Lexicon5Library.Json;
using Lexicon5Library.Library;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Members;

// Child class of User.
public class Admin : User
{
    //Constructor that automatically sets the role to Admin.
    public Admin(string email, string password, string name, string lastName)
        : base(email, password, name, lastName)
    {
        Role = UserRole.Admin;
    }

    //Method that allows for the removal of a book by ISBN.
    internal static void RemoveBook(List<Book> books)
    {
        //Print list so the user can see the ISBN of the books.
        PrintList(books);
        Console.Write("Write ISBN of book: ");
        //Take input and see if the input exists as a ISBN in the list of books.
        bool success = long.TryParse(Console.ReadLine(), out long ISBN);
        var removedBook = books.Find(book => book.Isbn == ISBN);
        Console.WriteLine();

        //If the book exists and the input was valid.
        if (success & removedBook != null)
        {
            string deleteInput = InputString($"Are you sure you want to delete this book: " +
            $"{removedBook!.Title}, {removedBook.Author}{Environment.NewLine}" +
            $"Type \"delete\" to delete. Otherwise just hit enter.");

            //Asks the user if they are sure they want to delete the book.
            if (deleteInput.ToLower() == "delete")
            {
                //Removes the book from the list and saves the list to the JSON file.
                books.Remove(removedBook);
                Console.WriteLine($"Book {removedBook.Title} has been removed.");
                JsonHandler.JsonSaveGeneric(books, JsonHandler.libraryFilePath);
            }
            else
                Console.WriteLine("The book was not removed.");
        }
        //If the book does not exist or the list is empty the user gets an error message.
        else if (books.Count == 0)
            Console.WriteLine("The library is empty.");
        else
            Console.WriteLine("The book you want to remove does not exist.");

        Console.WriteLine();
    }
    //Add book to the list and save it to the JSON file.
    public static void AddBook(List<Book> books)
    {
        //User input for the book.
        string title = InputString("Title: ");
        string author = InputString("Author: ");
        Console.Write($"ISBN: ");
        _ = long.TryParse(Console.ReadLine(), out long isbn);
        Console.Write($"Category: {Environment.NewLine}");

        //Prints the categories for the user to choose from.
        foreach (var c in Enum.GetValues<BookCategory>())
        {
            Console.WriteLine($"{(int)c + 1}.{c}");
        }

        //Creates a variable for the category.
        _ = int.TryParse(Console.ReadLine(), out int categoryInt);
        BookCategory category = (BookCategory)categoryInt - 1;

        try
        {
            //Validates the input. Error if the input is not valid.
            Book.ValidateInput(title, author, isbn, category, books);
            //If the input is valid create a new book, add it to the list and save it to the JSON file.
            Book book = new(title, author, isbn, category);
            Console.WriteLine($"Book {title} created!");
            books.Add(book);
            JsonHandler.JsonSaveGeneric(books, JsonHandler.libraryFilePath);
        }
        catch (ArgumentException e)
        {
            //If the input is not valid print the error message.
            e.Message.ErrorMessage();
        }
    }

}
