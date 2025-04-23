

namespace Lexicon5Library;

internal class Program
{
    //TODO
    //Admin panel/user panel
    //Add/remove category
    static void Main(string[] args)
    {
        List<Book> books =
    [
        new Book("1984", "George Orwell", 123456789, "Dystopian"),
        new Book("To Kill a Mockingbird", "Harper Lee", 234567890, "Classic"),
        new Book("The Great Gatsby", "F. Scott Fitzgerald", 345678901, "Classic"),
        new Book("Moby Dick", "Herman Melville", 456789012, "Adventure"),
        new Book("The Hobbit", "J.R.R. Tolkien", 567890123, "Fantasy"),
        new Book("Harry Potter", "J.K. Rowling", 678901234, "Fantasy"),
        new Book("Pride and Prejudice", "Jane Austen", 789012345, "Romance"),
        new Book("The Catcher in the Rye", "J.D. Salinger", 890123456, "Literary Fiction"),
        new Book("Brave New World", "Aldous Huxley", 901234567, "Science Fiction"),
        new Book("The Odyssey", "Homer", 123450987, "Epic"),
        new Book("Fahrenheit 451", "Ray Bradbury", 234560987, "Dystopian"),
        new Book("Animal Farm", "George Orwell", 345670987, "Satire"),
        new Book("Jane Eyre", "Charlotte Brontë", 456780987, "Romance"),
        new Book("The Alchemist", "Paulo Coelho", 567890987, "Adventure"),
        new Book("Lord of the Flies", "William Golding", 678900987, "Classic"),
        new Book("The Shining", "Stephen King", 789010987, "Horror"),
        new Book("It", "Stephen King", 890120987, "Horror"),
        new Book("The Road", "Cormac McCarthy", 901230987, "Post-Apocalyptic"),
        new Book("Dracula", "Bram Stoker", 112233445, "Gothic"),
        new Book("The Little Prince", "Antoine de Saint-Exupéry", 998877665, "Children's Literature")
    ];//Temp data
        string input;



        while (true)
        {
            Console.WriteLine("Write one of the options." +
                "1. Create book" +
                "2. List books" +
                "3. Borrow book" +
                "4. Remove book" +
                "4. add category" +
                "4. remove category" +
                "4. login" +
                "4. admin area" +
                "4. user area" +
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
                    JsonSaveLibrary();
                    JsonLoadLibrary();
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
    static void JsonLoadLibrary()
    {
        throw new NotImplementedException();
    }
    static void JsonSaveLibrary()
    {
        throw new NotImplementedException();
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
