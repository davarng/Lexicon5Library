using Lexicon5Library.Json;
using System.Security.Cryptography;
using static Lexicon5Library.Utility;

namespace Lexicon5Library.Members;

static class AccountService
{
    internal static void SignUp(List<User> users)
    {
        string email = InputString("Email: ");
        string firstName = InputString("First name: ");
        string lastName = InputString("Last name: ");
        string password = InputString("Password(min 10 chars): ");
        string secret = InputString("Admin secret code");//secret

        try
        {
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

    internal static User? SignIn(List<User> users)
    {
        string email = InputString("Enter your email: ");
        string password = InputString("Enter your password: ");

        Console.Clear();

        var user = users.FirstOrDefault(user => user.Email == email);

        if (user != null || users.Count > 0)
        {
            var saltHash = user!.Password.Split(':');
            byte[] salt = Convert.FromBase64String(saltHash[0]);

            using var passwordHasher = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

            string hash = Convert.ToBase64String(passwordHasher.GetBytes(32));

            if (hash == saltHash[1])
            {
                Console.WriteLine($"Welcome back to the library {user.Name} {user.LastName}");
                return user;
            }
        }

        Console.WriteLine("Invalid email or password.");
        return null;
    }

    private static string HashAndSaltPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        //disposed
        using var passwordHasher = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);

        byte[] hash = passwordHasher.GetBytes(32);

        string hashAndSalt = Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

        return hashAndSalt;
    }
}
