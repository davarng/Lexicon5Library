using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Library;

public static class BookSearchHandler
{

    internal static void BookSearchSelection(this List<Book> books)
    {
        Console.Clear();
        string input = InputString($"What would you like to search by?{Environment.NewLine}" +
            $"1. Author{Environment.NewLine}" +
            $"2. Title{Environment.NewLine}" +
            $"3. Isbn{Environment.NewLine}" +
            $"4. Category");

        switch (input)
        {
            case "1":
                BookSearch(books, ByAuthor);

                break;
            case "2":
                BookSearch(books, ByTitle);

                break;
            case "3":
                BookSearch(books, ByIsbn);

                break;
            case "4":
                BookSearch(books, ByCategory);

                break;
            default:
                Console.WriteLine("Invalid search term.");

                break;
        }
    }

    //String version
    private static void BookSearch(List<Book> books, Func<List<Book>, string, List<Book>> searchBy)
    {
        string searchWord = InputString("Write word to search for: ");
        Person.PrintList(searchBy(books, searchWord));
    }

    //Int version
    private static void BookSearch(List<Book> books, Func<List<Book>, long, List<Book>> searchBy)
    {
        Console.Write("Write word to search for: ");
        bool success = long.TryParse(Console.ReadLine(), out long searchInt);
        if (success)
            Person.PrintList(searchBy(books, searchInt));
        else
            Console.WriteLine("Not a valid isbn...");
    }

    private static List<Book> ByAuthor(List<Book> books, string searchWord)
    {
        var searchedBooks = books.Where(book => book.Author
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

    private static List<Book> ByTitle(List<Book> books, string searchWord)
    {
        var searchedBooks = books.Where(book => book.Title
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

    private static List<Book> ByIsbn(List<Book> books, long searchWord)
    {
        var searchedBooks = books.Where(book => book.Isbn == searchWord).ToList();

        return searchedBooks;
    }

    private static List<Book> ByCategory(List<Book> books, string searchWord)
    {
        var searchedBooks = books.Where(book => book.Category.ToString()
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

}
