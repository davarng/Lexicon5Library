namespace Lexicon5Library
{
    public static class Utility
    {
        //Method that prints an error message in red.
        public static void ErrorMessage(this string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Environment.NewLine}ERROR:{Environment.NewLine}{message}");
            Console.ResetColor();
        }

        //Method that takes string message writes it out and then returns the users input
        public static string InputString(string question)
        {
            Console.Write(question);
            return Console.ReadLine() ?? "";
        }
    }
}
