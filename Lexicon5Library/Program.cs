using Lexicon5Library.Json;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Xml;

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
                $"4. Borrow book{Environment.NewLine}" +
                $"5. add category{Environment.NewLine}" +
                $"6. remove category{Environment.NewLine}" +
                $"7. login{Environment.NewLine}" +
                $"8. admin area{Environment.NewLine}" +
                $"9. user area{Environment.NewLine}" +
                $"Q. Quit application.");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBook(books);
                    break;
                case "2":
                    PrintList(books);
                    break;
                case "3":
                    RemoveBook(books);
                    break;
                case "4":
                    SearchForBook();
                    break;
                case "5":

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

    #region ADMIN OPERATIONS
    static void RemoveBook(List<Book> books)
    {
        PrintList(books);
        Console.Write("Write ISBN of book: ");
        bool success = int.TryParse(Console.ReadLine(), out int ISBN);

        if (success && books.Count != 0)
        {
            var removedBook = books.Find(book => book.Isbn == ISBN);
            if (removedBook != null)
            {
                Console.WriteLine($"Are you sure you want to delete this book: {removedBook.Title}, {removedBook.Author}{Environment.NewLine}" +
                    $"Type: \"delete\" to delete.");
                var deleteInput = Console.ReadLine().ToLower();
                if (deleteInput == "delete")
                {
                    books.Remove(removedBook);
                    Console.WriteLine($"Book {removedBook.Title} has been removed.");
                    JsonHandler.JsonSaveLibrary(books);
                }
            }
        }
        else
            Console.WriteLine("Book doesnt exist.");
    }

    private static void AddBook(List<Book> books)
    {
        Console.Clear();
        Console.Write("TITLE: ");
        string title = Console.ReadLine();
        Console.Write($"Author: ");
        string author = Console.ReadLine();
        Console.Write($"ISBN: ");
        bool success = int.TryParse(Console.ReadLine(), out int isbn);
        Console.Write($"Category: ");
        string category = Console.ReadLine();

        Book book = new(title, author, isbn, category);
        Console.WriteLine($"Book {title} created!{Environment.NewLine}");
        books.Add(book);
        JsonHandler.JsonSaveLibrary(books);
    }


    #endregion

    #region USER OPERATIONS
    private static void PrintList(List<Book> listOfBooks)
    {
        Console.Clear();
        foreach (var book in listOfBooks)
        {
            Console.WriteLine($"{book}{Environment.NewLine}" +
                $"---------------------------------");

        }
        Console.WriteLine();
    }
    #endregion


    static void SearchForBook()
    {
        throw new NotImplementedException();
    }



}
