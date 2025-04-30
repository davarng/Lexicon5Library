# 📚 Lexicon5Library - C# Console Library App

## Description
**Lexicon5Library** is a C# console application designed to manage a collection of books. This library app lets you:
-  Print a list of books
-  Create and add new books to the collection
-  Remove books from the collection
-  Search for books based on attributes like ISBN, title, category, author, and availability
-  Change the availability status of books (e.g., Available, Checked-out)
-  Store and load books from a **JSON file** for persistent storage


## Instructions
### Clone the file in vscode and start the application
This will load the books that already exist. If everything goes to plan you will see the text "Library loaded". If an error occurs then check the filePath variable in JsonHandler to make sure the location is correct.

### Menu selection
Read the menu and chose one of the selections and hit enter.

- **1 Add New Book**: Create new books and store them in the system.
  - Title: Write a title that is valid(1-300 characters) and hit enter.
  - Author: Write an author that is valid(2-200 characters) and hit enter.
  - ISBN: Write an isbn that is valid(10-13 numbers and does not exist on another book in the system) and hit enter.
  - Category: Enter one of the numbers in the list of categories you see(example "2" for fantasy) and hit enter.
 
  If everything went right you get a message telling you the book was created.  
  If the input(s) was faulty you will be told which input(s) was faulty in a red error message.
- **2 View All Books**: Display all books stored in the system.
  - ISBN
  - Title
  - Category
  - Author
  - Availability
- **3 Remove Book**: Delete books from the collection by ISBN.
  - ISBN
  - Title
  - Category
  - Author
  - Availability
- **4 Search Books**: Search books by:
  - ISBN
  - Title
  - Category
  - Author
  - Availability
- **5 Change Availability**: Toggle the availability of a book (e.g., Available, Checked-out).
  - ISBN
  - Title
  - Category
  - Author
  - Availability

## Tests
Before running the application, make sure you have the following installed:
- .NET
