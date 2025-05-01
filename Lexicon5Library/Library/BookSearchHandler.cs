using Lexicon5Library.Members;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Library;

//Class for searching books in the library.
public static class BookSearchHandler
{
    //Extension method that lets you choose which field in a book to search for.
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

    //String version of BookSearch that helps you search for books by title, author, category or availability.
    private static void BookSearch(List<Book> books, Func<List<Book>, string, List<Book>> searchBy)
    {
        string searchWord = InputString("Write word to search for: ");
        Console.Clear();
        // Uses the Func passed to the method to search for books.
        var output = searchBy(books, searchWord);

        //If the output list contains books it will print them. If not it will print that no results were found.
        if (output.Count > 0)
            User.PrintList(output);
        else
            Console.WriteLine("No results found.");
    }

    //Int version that helps you search for books by isbn.
    private static void BookSearch(List<Book> books, Func<List<Book>, long, List<Book>> searchBy)
    {
        Console.Write("Write number to search for: ");
        //Tries to parse the input to a long. If it fails it will print that it is not a valid isbn.
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

    //Search that helps you search for books by author. All these methods are using LINQ to search for books.
    private static List<Book> ByAuthor(List<Book> books, string searchWord)
    {
        //All searches are case insensitive and will show partial matches(Example: "The" will show all books that contain the word "The")
        var searchedBooks = books.Where(book => book.Author
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

    //Search that helps you search for books by availability.
    private static List<Book> ByAvailable(List<Book> books, string searchWord)
    {
        searchWord = searchWord.ToLower();
        //Shows all books that are available or not available. If the search word is not "true" or "false" it will show all books.
        var boolBooks = books.Where(book => book.IsAvailable == 
        (searchWord == "true" ? true : searchWord == "false" ? false : true || false)).ToList();

        return boolBooks;
    }

    //Search that helps you search for books by title.
    private static List<Book> ByTitle(List<Book> books, string searchWord)
    {
        var searchedBooks = books.Where(book => book.Title
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

    //Search that helps you search for books by isbn.
    private static List<Book> ByIsbn(List<Book> books, long searchWord)
    {
        var searchedBooks = books.Where(book => book.Isbn == searchWord).ToList();

        return searchedBooks;
    }

    //Search that helps you search for books by category.
    private static List<Book> ByCategory(List<Book> books, string searchWord)
    {
        var searchedBooks = books.Where(book => book.Category.ToString()
        .Contains(searchWord, StringComparison.OrdinalIgnoreCase)).ToList();

        return searchedBooks;
    }

}
