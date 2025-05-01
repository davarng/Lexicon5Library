namespace Lexicon5Library.Library;

//Not implemented yet.
class BorrowedBooks
{
    private Book book;
    private string user; 
    private DateOnly borrowDate;
    private DateOnly expiryDate;


    public BorrowedBooks(Book book, string user)
    {
        this.book = book;
        this.user = user;
        borrowDate = DateOnly.FromDateTime(DateTime.Now);
        expiryDate = borrowDate.AddDays(7);
    }
}
