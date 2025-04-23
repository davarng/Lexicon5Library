using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon5Library;

class BorrowedBooks
{
    private Book book; //make sure it exists and isnt null
    private string user; //TODO
    private DateOnly borrowDate;
    private DateOnly expiryDate;


    public BorrowedBooks(Book book, string user)
    {
        this.book = book;
        this.user = user;
        this.borrowDate = DateOnly.FromDateTime(DateTime.Now);
        this.expiryDate = borrowDate.AddDays(7);
    }
}
