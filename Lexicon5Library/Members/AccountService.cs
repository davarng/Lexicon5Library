using Lexicon5Library.Json;
using System.Security.Cryptography;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Members;

// This class handles user account operations like signing up and signing in.
static class AccountService
{
    //Sign up method that adds a new user to the list of users and saves it to the JSON file.
    internal static void SignUp(List<User> users)
    {
        string email = InputString("Email: ");
        string firstName = InputString("First name: ");
        string lastName = InputString("Last name: ");
        string password = InputString("Password(min 10 chars): ");
        string secret = InputString("Admin secret code");//Secret code for creating an admin account. If no code is entered, a user account is created.

        //Validation is not implemented yet.
        try
        {
            //Using the UserFactory class to create a new user object and calls the HashAndSaltPassword method to hash the password.
            Console.WriteLine($"Account created!");
            users.Add(UserFactory.CreateUser((secret == "secret" ? "admin" : "user"), email,
                HashAndSaltPassword(password), firstName, lastName));

            JsonHandler.JsonSaveGeneric(users, JsonHandler.userFilePath);
        }
        catch (ArgumentException e)
        {
            e.Message.ErrorMessage();
        }
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
