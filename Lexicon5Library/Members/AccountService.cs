using Lexicon5Library.Json;
using Lexicon5Library.Library;
using System.Security.Cryptography;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Members;

// This class handles user account operations like signing up and signing in.
static class AccountService
{   
    public static void UserLoginScreen(List<User> users, ref User? loggedInUser)
    {
        //User has to log in before using the application.
        string accountInput = InputString($"1. Login{Environment.NewLine}" +
            $"2. Create account{Environment.NewLine}" +
            $"Q. Quit application{Environment.NewLine}");

        switch (accountInput)
        {
            case "1":
                //User chose 1 so we call the SignIn method from AccountService class.
                loggedInUser = AccountService.SignIn(users);
                break;
            case "2":
                //User chose 2 so we call the SignUp method from AccountService class.
                AccountService.SignUp(users);
                break;
            case "Q":
            case "q":
                //Quits the application.
                Console.WriteLine($"{Environment.NewLine}Closing application window...");
                Environment.Exit(0);
                break;
            default:
                //If the user input is not valid we print a message.
                Console.WriteLine("Your input is not valid");
                break;
        }
    }

    //Sign up method that adds a new user to the list of users and saves it to the JSON file.
    internal static void SignUp(List<User> users)
    {
        string email = InputString("Email: ");
        string firstName = InputString("First name: ");
        string lastName = InputString("Last name: ");
        string password = InputString("Password(min 10 chars): ");
        string secret = InputString("Admin secret code: ");//Secret code for creating an admin account. If no code is entered, a user account is created.

        //Validation is not implemented yet.
        try
        {   //Checks if the email is unique and if the fields are valid.
            ValidateInputUser(email, firstName, lastName, password, users);

            //Using the UserFactory class to create a new user object and calls the HashAndSaltPassword method to hash the password.
            users.Add(UserFactory.CreateUser((secret == "secret" ? "admin" : "user"), email,
                HashAndSaltPassword(password), firstName, lastName));

            Console.Clear();
            //Upload the user.
            JsonHandler.JsonSaveGeneric(users, JsonHandler.userFilePath);
            Console.WriteLine($"Account created!");
        }
        catch (ArgumentException e)
        {
            e.Message.ErrorMessage();
        }
    }

    //Validate user input for the sign up method.
    internal static void ValidateInputUser(string email, string firstName, string lastName, string password, List<User> users)
    {
        //Empty error message string. Lets me add multiple error messages to the same string.
        string errorMessage = "";
        //Check if the email already exists in the list of users.
        var duplicateEmail = users.Find(u => u.Email == email);

        //Check if the email is a valid length and if it contains @ and . in the right order.
        if (email.Length < 6 || email.Length > 200 ||
            email.IndexOf('@') > email.LastIndexOf('.') ||
            !email.Contains('@') || !email.Contains('.') ||
            duplicateEmail != null)
            //Adds to the error message if the email is not valid.
            errorMessage += $"The Email is not valid(Unique, 6-200 characters and contains @ and . in the right order). " +
                $"{(duplicateEmail != null ? "A user with that email already exists." : "Email format invalid.")}{Environment.NewLine}";
        
        //Check if the firstname length is valid.
        if (firstName.Length < 2 || firstName.Length > 100)
            errorMessage += $"The first name is not valid(2-100 characters). " +
                $"Your firstname length: {firstName.Length} characters.{Environment.NewLine}";

        //Check if the last name length is valid.
        if (lastName.Length < 2 || lastName.Length > 100)
            errorMessage += $"The last name is not valid(2-100 characters)." +
                $"Your last name length: {lastName.Length} characters{Environment.NewLine}";

        //Check if the password is valid.
        if (password.Length < 5 || password.Length > 128)
            errorMessage += $"The password length is not valid(5-128 characters)." +
                $"Your password length: {password.Length} characters{Environment.NewLine}";

        //Check if the error message is empty. If it is not empty throw an exception with the error message.
        if (errorMessage.Length > 0)
            throw new ArgumentException(errorMessage);
    }

    //Sign in method that can return null if the user is not found or the password is incorrect.
    internal static User? SignIn(List<User> users)
    {
        string email = InputString("Enter your email: ");
        string password = InputString("Enter your password: ");

        Console.Clear();

        //Checks if a user with the given email exists in the list of users. The plan is to make email unique in the future.
        var user = users.FirstOrDefault(user => user.Email == email);

        //If the user is found.
        if (user != null)
        {
            //Splits the password into salt and hash. The password is stored as "salt:hash" in the JSON file.
            var saltHash = user!.Password.Split(':');
            // Gets the salt from the password And converts it from string to a byte array.
            byte[] salt = Convert.FromBase64String(saltHash[0]);

            //Encrypts the input password with the same salt and hash algorithm as the one used to create the password.
            using var passwordHasher = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

            //Converts the hash to a string.
            string hash = Convert.ToBase64String(passwordHasher.GetBytes(32));

            //Checks if the hash of the input password matches the hash stored in the user objects that matches the email the user put in.
            if (hash == saltHash[1])
            {
                //If the password is correct the user is returned to the program file and saved in the loggedInUser variable.
                Console.WriteLine($"Welcome back to the library {user.Name} {user.LastName}");
                return user;
            }
        }

        //If the user is not found or if the password doesn't match the user return null.
        Console.WriteLine("Invalid email or password.");
        return null;
    }

    //Method to hash and salt the password.
    private static string HashAndSaltPassword(string password)
    {
        //Create a random salt.
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        //Hash the password with the salt.
        using var passwordHasher = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

        //Take the hash and concatenate it with the salt using a ":" in the middle to make separation possible.
        byte[] hash = passwordHasher.GetBytes(32);

        string hashAndSalt = Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        //Then return the string.
        return hashAndSalt;
    }
}
