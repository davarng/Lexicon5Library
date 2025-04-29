namespace Lexicon5Library.Library;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public long Isbn { get; set; }
    public BookCategory Category { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, long isbn, BookCategory category)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        Category = category;
        IsAvailable = true;
    }

    internal static void ValidateInput(string title, string author, long isbn, BookCategory category, List<Book> books)
    {
        string errorMessage = "";
        var duplicateIsbn = books.Find(b => b.Isbn == isbn);
        int isbnLength = isbn.ToString().Length;

        if (title.Length < 1 || title.Length > 300)
            errorMessage += $"The title is not valid(1-300 characters). " +
                $"Your title length: {title.Length} characters.{Environment.NewLine}";

        if (author.Length < 2 || author.Length > 100)
            errorMessage += $"The author is not valid(2-100 characters). " +
                $"Your author length: {author.Length} characters.{Environment.NewLine}";

        if (isbnLength < 10 || isbnLength > 13 || duplicateIsbn != null)
            errorMessage += $"The ISBN is not valid(10-13 numbers and unique). {(duplicateIsbn == null ?
                $"Your ISBN length: {isbnLength}" :
                $"ISBN already exists: {duplicateIsbn.Title}: {duplicateIsbn.Isbn}")}" +
                $".{Environment.NewLine}";

        if (!Enum.IsDefined(category))
            errorMessage += $"The category does not exist.{Environment.NewLine}";

        if (errorMessage.Length > 0)
            throw new ArgumentException(errorMessage);
    }

    public override string ToString()
    {
        return $"Title: {Title}{Environment.NewLine}" +
            $"Author: {Author}{Environment.NewLine}" +
            $"ISBN: {Isbn}{Environment.NewLine}" +
            $"Category: {Category}{Environment.NewLine}" +
            $"Is available: {IsAvailable}";
    }

}
