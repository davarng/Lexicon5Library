using Lexicon5Library.Json;
using Lexicon5Library.Library;
using static Lexicon5Library.Utility;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lexicon5Library
{

    public class Person
    {
        //List book => book
        internal static void SetBookStatus(List<Book> books)
        {
            PrintList(books);
            Console.Write("Write ISBN of book: ");
            bool success = long.TryParse(Console.ReadLine(), out long ISBN);
            var book = books.Find(book => book.Isbn == ISBN);

            if (success & book != null)
            {
                book!.IsAvailable = !book.IsAvailable;
            }
            else if (books.Count == 0)
                Console.WriteLine("No books to change status on.");
            else
                Console.WriteLine("The book you chose does not exist.");
        }
        internal static void SetBookAvailable(Book book)
        {
            //book false
            book.IsAvailable = true;
        }
        internal static void SetBookNotAvailable(Book book)
        {
            //book true
            book.IsAvailable = false;
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

                if (deleteInput == "delete")
                {
                    books.Remove(removedBook);
                    Console.WriteLine($"Book {removedBook.Title} has been removed.");
                    JsonHandler.JsonSaveLibrary(books);
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
                Console.WriteLine($"Book {title} created!{Environment.NewLine}");
                books.Add(book);
                JsonHandler.JsonSaveLibrary(books);
            }
            catch (ArgumentException e)
            {
                e.Message.ErrorMessage();
            }
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
}
