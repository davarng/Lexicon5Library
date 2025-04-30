namespace Lexicon5Library
{
    public static class Utility
    {
        public static void ErrorMessage(this string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Environment.NewLine}ERROR:{Environment.NewLine}{message}");
            Console.ResetColor();
        }

        public static string InputString(string question)
        {
            Console.Write(question);
            return Console.ReadLine() ?? "";
        }
    }
}
