using Lexicon5Library.Members;

namespace Lexicon5Library.Library;

//Not implemented yet.
public class BorrowedBooks
{
    public User User { get; private set; }
    public DateOnly BorrowDate { get; private set; }
    public DateOnly ExpiryDate { get; private set; }

    public BorrowedBooks(User user)
    {
        User = user;
        BorrowDate = DateOnly.FromDateTime(DateTime.Now);
        ExpiryDate = BorrowDate.AddDays(7);
    }

}
