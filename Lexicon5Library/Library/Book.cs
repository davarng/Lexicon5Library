namespace Lexicon5Library.Library;

class Book
{
    private string title;
    private string author;
    private long isbn;
    private BookCategory category;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    public long Isbn
    {
        get { return isbn; }
        set { isbn = value; }
    }

    public BookCategory Category
    {
        get { return category; }
        set { category = value; }
    }

    public Book(string title, string author, long isbn, BookCategory category)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.category = category;
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
        return $"Title: {title}{Environment.NewLine}" +
            $"Author: {author}{Environment.NewLine}" +
            $"ISBN: {isbn}{Environment.NewLine}" +
            $"Category: {category.ToString()}";
    }

}
