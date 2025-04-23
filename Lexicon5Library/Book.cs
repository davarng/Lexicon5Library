using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon5Library;

class Book
{
    private string title;// 150 chars
    private string author;// 50 chars
    private int isbn; //10 chars
    private string category; //Enum?

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
    public int Isbn
    {
        get { return isbn; }
        set { isbn = value; }
    }

    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    public Book(string title, string author, int isbn, string category)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.category = category;
    }

    public override string ToString()
    {
        return $"Title: {title}{Environment.NewLine}" +
            $"Author: {author}{Environment.NewLine}" +
            $"ISBN: {isbn}{Environment.NewLine}" +
            $"Category: {category}";
    }

}
