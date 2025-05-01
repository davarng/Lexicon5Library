namespace Lexicon5Library.Library;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public long Isbn { get; set; }
    //Enum for book categories.
    public BookCategory Category { get; set; }
    //Boolean to check if the book is available or not.
    public bool IsAvailable { get; set; }

    //Set isAvailable to true by default.
    public Book(string title, string author, long isbn, BookCategory category)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        Category = category;
        IsAvailable = true;
    }

    //Method to validate the input when creating a new book. Requires the fields of book and a list of books to check for duplicates.
    internal static void ValidateInputBook(string title, string author, long isbn, BookCategory category, List<Book> books)
    {
        //Empty error message string. Lets me add multiple error messages to the same string.
        string errorMessage = "";
        //Check if the ISBN already exists in the list of books.
        var duplicateIsbn = books.Find(b => b.Isbn == isbn);
        //Isbn length.
        int isbnLength = isbn.ToString().Length;

        //Check if the title length is valid.
        if (title.Length < 1 || title.Length > 300)
            //Adds to the error message if the title length is not valid.
            errorMessage += $"The title is not valid(1-300 characters). " +
                $"Your title length: {title.Length} characters.{Environment.NewLine}";

        //Check if the author length is valid.
        if (author.Length < 2 || author.Length > 100)
            errorMessage += $"The author is not valid(2-100 characters). " +
                $"Your author length: {author.Length} characters.{Environment.NewLine}";

        //Check if the ISBN length is valid and not a duplicate. Error message will be different if the ISBN is a duplicate or not.
        if (isbnLength < 10 || isbnLength > 13 || duplicateIsbn != null)
            errorMessage += $"The ISBN is not valid(10-13 numbers and unique). {(duplicateIsbn == null ?
                $"Your ISBN length: {isbnLength}" :
                $"ISBN already exists: {duplicateIsbn.Title}: {duplicateIsbn.Isbn}")}" +
                $".{Environment.NewLine}";

        //Check if the category is valid.
        if (!Enum.IsDefined(category))
            errorMessage += $"The category does not exist.{Environment.NewLine}";

        //Check if the error message is empty. If it is not empty throw an exception with the error message.
        if (errorMessage.Length > 0)
            throw new ArgumentException(errorMessage);
    }

    //Override the ToString method.
    public override string ToString()
    {
        return $"Title: {Title}{Environment.NewLine}" +
            $"Author: {Author}{Environment.NewLine}" +
            $"ISBN: {Isbn}{Environment.NewLine}" +
            $"Category: {Category}{Environment.NewLine}" +
            $"Is available: {IsAvailable}";
    }

}
