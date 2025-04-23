using System.Text.Json;

namespace Lexicon5Library;

internal class Program
{
    //TODO
    //Admin panel/user panel
    //Add/remove category
    static void Main(string[] args)
    {
        List<Book> books = [];
        JsonLoadLibrary(ref books);
        string input;

        while (true)
        {
            Console.WriteLine("Write one of the options." +
                "1. Create book" +
                "2. List books" +
                "3. Borrow book" +
                "4. Remove book" +
                "5. add category" +
                "6. remove category" +
                "7. login" +
                "8. admin area" +
                "9. user area" +
                "Q.");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    books.Add(AddBook());
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
                    JsonSaveLibrary(books);
                    break;
                case "Q":
                case "q":
                    Console.WriteLine("Closing application window...");

                    return;
                default:
                    Console.WriteLine("Your input is not valid");

                    break;
            }
        }

    }

    static bool JsonFileExists(string jsonBooksPath)
    {
        if (File.Exists(jsonBooksPath))
        {
            return true;
        }
        else
        {
            Console.WriteLine("File not found...");
            return false;
        }
    }

    static void JsonLoadLibrary(ref List<Book> listOfBooks)
    {
        string jsonBooksPath = @"C:\Lexicon kod\LexiconUppgifter\Lexicon5Library\Lexicon5Library\LibraryJSON.json";
        if (!JsonFileExists(jsonBooksPath)) return;

        listOfBooks = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(jsonBooksPath));
        Console.WriteLine("loaded books");
    }
    static void JsonSaveLibrary(List<Book> listOfBooks)
    {
        string jsonBooksPath = @"C:\Lexicon kod\LexiconUppgifter\Lexicon5Library\Lexicon5Library\LibraryJSON.json";
        if (!JsonFileExists(jsonBooksPath)) return;

        string useless = JsonSerializer.Serialize(listOfBooks);
        File.WriteAllText(jsonBooksPath, useless);
        Console.WriteLine("Finished saving to file.");
    }

    private static void PrintList(List<Book> listOfBooks)
    {
        foreach (var book in listOfBooks)
        {
            Console.WriteLine($"{book}{Environment.NewLine}" +
                $"---------------------------------");

        }
    }

    static void SearchForBook()
    {
        throw new NotImplementedException();
    }

    private static Book AddBook()
    {
        Console.WriteLine("TITLE");
        string title = Console.ReadLine();
        Console.WriteLine("AUTHOR");
        string author = Console.ReadLine();
        Console.WriteLine("ISBN");
        bool success = int.TryParse(Console.ReadLine(), out int isbn);
        Console.WriteLine("CATEGORY");
        string category = Console.ReadLine();


        Book book = new(title, author, isbn, category);

        return book;
    }
    static void RemoveBook(List<Book> books)
    {
        PrintList(books);
        Console.WriteLine("Write index of book");
        bool success = int.TryParse(Console.ReadLine(), out int index);

        if (success && index <= books.Count && books.Count != 0)
        {
            index -= 1;
            var removedBook = books[index].Title;

            books.RemoveAt(index);
            Console.WriteLine($"{removedBook} has been removed.");
        }
        else
            Console.WriteLine("Book doesnt exist.");
    }
}
