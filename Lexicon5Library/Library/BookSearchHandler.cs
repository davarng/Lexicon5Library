using Lexicon5Library.Members;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Library;

public static class BookSearchHandler
{

    internal static void BookSearchSelection(this List<Book> books)
    {
        string input = InputString($"What would you like to search by?{Environment.NewLine}" +
            $"1. Author{Environment.NewLine}" +
            $"2. Title{Environment.NewLine}" +
            $"3. Isbn{Environment.NewLine}" +
            $"4. Category{Environment.NewLine}");

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
            case "5":
                BookSearch(books, ByAvailable);

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
        Console.Clear();
        var output = searchBy(books, searchWord);

        if (output.Count > 0)
            User.PrintList(output);
        else
            Console.WriteLine("No results found.");
    }

    //Int version
    private static void BookSearch(List<Book> books, Func<List<Book>, long, List<Book>> searchBy)
    {
        Console.Write("Write number to search for: ");
        bool success = long.TryParse(Console.ReadLine(), out long searchInt);
        if (success)
        {
            Console.Clear();
            var output = searchBy(books, searchInt);

            if (output.Count > 0)
                User.PrintList(output);
            else
                Console.WriteLine("No results found.");
        }
        else
            Console.WriteLine("Not a valid isbn...");
    }

    private static List<Book> ByAuthor(List<Book> books, string searchWord)
    {
        var searchedBooks = books.Where(book => book.Author
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

    private static List<Book> ByAvailable(List<Book> books, string searchWord)
    {
        searchWord = searchWord.ToLower();

        var boolBooks = books.Where(book => book.IsAvailable == (searchWord == "true" ? true : searchWord == "false" ? false : true || false)).ToList();

        return boolBooks;
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
