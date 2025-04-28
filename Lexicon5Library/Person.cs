using Lexicon5Library.Json;
using Lexicon5Library.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon5Library
{
    internal class Person
    {
        internal static void RemoveBook(List<Book> books)
        {
            PrintList(books);
            Console.Write("Write ISBN of book: ");
            bool success = long.TryParse(Console.ReadLine(), out long ISBN);

            if (success && books.Count != 0)
            {
                var removedBook = books.Find(book => book.Isbn == ISBN);
                if (removedBook != null)
                {
                    Console.WriteLine($"Are you sure you want to delete this book: " +
                        $"{removedBook.Title}, {removedBook.Author}{Environment.NewLine}" +
                        $"Type: \"delete\" to delete. Otherwise just hit enter.");

                    var deleteInput = Console.ReadLine() ?? "".ToLower();
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

        internal static void AddBook(List<Book> books)
        {
            Console.Clear();

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";
            Console.Write($"Author: ");
            string author = Console.ReadLine() ?? "";
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
            Console.Clear();

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
