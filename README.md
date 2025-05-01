<div align="left">

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
This will load the books and users that already exist. If everything goes to plan you will see the text "Library loaded"/"User loaded". If an error occurs then check the filePath variable in JsonHandler to make sure the location is correct.

### Login/Signup // Not fully implemented will make validation etc if enough time.
- **1. Create account(If you already have an account skip to 2.Login)**: Create a new account and login/signup with account that already exists. PREMADE ADMIN ACCOUNT: email = admin@mail.com, password = admin 
  - Give input for email, first name, last name, password, and if you are an admin give the secret code to create an admin account otherwise just hit enter. ADMIN SECRET CODE = secret
  - Result output telling you if account creation succeeded or not.

- **2. Login**:
  - Enter your email and password(Case sensitive).
  - If the application finds the user you will become logged in and enter the menu selection. Otherwise the program will tell you that no match was found.

### Menu selection
Read the menu and chose one of the selections and hit enter. Options marked admin are admin exclusive. I'm working on fixing this right now but inc

- **1. Add New Book**: Create new books and store them in the system.
  - Title: Write a title that is valid(1-300 characters) and hit enter.
  - Author: Write an author that is valid(2-200 characters) and hit enter.
  - ISBN: Write an isbn that is valid(10-13 numbers and does not exist on another book in the system) and hit enter.
  - Category: Enter one of the numbers in the list of categories you see(example "2" for fantasy) and hit enter.
 
  If everything went right you get a message telling you the book was created.  
  If the input(s) was faulty you will be told which input(s) was faulty in a red error message.
- **2. View All Books**: Display all books stored in the system displayed in alphabetical order.
  
  - The list prints in alphabetical order unless the list is empty in which case it will say "The list is empty..."

- **3. Remove Book**: Delete books from the collection by ISBN.
  - List prints showing all the books.
  - ISBN: Write an ISBN of one of the books in the list.
  
  If your ISBN is valid
    
  - Prompt asking if you are sure. Write "delete" and hit enter if you are sure. Just hit enter if you do not want to delete.
  - Message stating whether item got deleted or not based on your input.

  If library is empty

  - Message stating "The library is empty.".
 
  If the ISBN is invalid

  - Message stating "The book you want to remove does not exist.".
  
- **4. Search Books**: Search books by:
  - Search category: Write one of the numbers shown in the selection list. Will give you a message if the input is invalid.
  - You will get a message asking for a search term. For Title, Category and Author write the name of the result you want to find(Example search Author: "Writer Mcwriter" will return all books written by that author). The search is not case sensitive and partial searches work here too(Example search Category: "mys" will          return all books that have a category containing mys)
  - For ISBN the search will require the exact ISBN of the book you are searching for(Example search ISBN: "1234567890" will find the book with that ISBN). Error message if the ISBN is not a number.
  - For Availability write true or false depending if you want to search for books that are or are not available(Example search Availability: "true" will return all the books that are available). If your search doesn't contain true or false it will simply return a list of all books.
  - If there are no results for your search you will get a message saying "No results found..."

- **5. Change Availability**: Toggle the availability of a book.
  - List prints of all the books.
  - Message asks for an ISBN. Write the exact number of the book you want to change(Example input: "1234567890" will change availability from either true to false or false to true.).

  If success
  - User will be told "Book {Title} is now {available/not available}" depending on which the change was.
 
  If the ISBN is invalid
  - User will be told "The book you chose does not exist".
 
  If the library is empty
  - User will be told "The library is empty".

## Tests



![image](https://github.com/user-attachments/assets/cf46145f-9a83-4cc1-a5dd-250d63d75eb1)

![image](https://github.com/user-attachments/assets/53dabed3-9bb1-4d5e-a211-b87b48921544)


</div>
