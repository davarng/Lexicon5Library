using Lexicon5Library;
using Lexicon5Library.Library;

namespace LibraryTest;

public class UnitTest1
{
    [Fact]
    public void CreateNewBook_WithValidInput_ShouldCreateBook()
    {
        //Arrange
        List<Book> books = new() { new("Name", "test", 123123123123, (BookCategory)1) };

        Console.SetIn(new StringReader("1984\nGeorge Orwell\n1987654321\n7\n"));

        //Act
        Person.AddBook(books);

        //Assert
        Assert.Equal(2, books.Count);
        Assert.NotNull(books[1]);
        Assert.Equal("1984", books[1].Title);
        Assert.Equal("George Orwell", books[1].Author);
        Assert.Equal(1987654321, books[1].Isbn);
        Assert.Equal((BookCategory)6, books[1].Category);
        Assert.True(books[1].IsAvailable);
    }

    [Theory]
    [InlineData("", "Author", "1234567890", "1")]           //Invalid title < 1 characters.
    [InlineData("Title", "", "1234567890", "1")]            //Invalid author < 2 characters.
    [InlineData("Title", "Author", "123456789", "1")]       //Invalid isbn < 10 characters.
    [InlineData("Title", "Author", "123123123123", "1")]    //Invalid isbn duplicate.
    [InlineData("Title", "Author", "1234567890", "0")]      //Invalid category does not exist.
    public void CreateNewBook_WithInvalidField_ShouldReturn(string title, string author, string isbn, string category)
    {
        //Arrange
        List<Book> books = [new("Name", "test", 123123123123, (BookCategory)1)];

        Console.SetIn(new StringReader($"{title}\n{author}\n{isbn}\n{category}\n"));

        //Act
        Person.AddBook(books);

        //Assert
        Assert.Single(books);
    }
}
