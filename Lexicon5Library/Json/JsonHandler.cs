using Lexicon5Library.Library;
using System.Text.Json;
namespace Lexicon5Library.Json;

internal static class JsonHandler
{
    //Paths to the JSON files. Works on my pc but unsure if it works on other computers. I had some problems getting this to work properly
    //If not just replace the path with the full path to the JSON files.
    public static readonly string libraryFilePath = Path.GetFullPath(@"..\..\..", Directory.GetCurrentDirectory()) + @"\Json\LibraryJSON.json";
    public static readonly string userFilePath = Path.GetFullPath(@"..\..\..", Directory.GetCurrentDirectory()) + @"\Json\UserJSON.json";

    //Check if the JSON file exists. If it does not exist, it will print a message and return false.
    private static bool JsonFileExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            return true;
        }
        else
        {
            Console.WriteLine("File not found...");
            return false;
        }
    }

    //Generic method to load JSON files to avoid having to create different JSON load methods.
    //Requires a ref list and file path as parameters.
    public static void JsonLoadGeneric<T>(ref List<T> listOfGenerics, string filePath)
    {
        //Checks if the file exists. If it doesn't exist the method will quit.
        if (!JsonFileExists(filePath)) return;

        //Loads the json file into a string.
        var listOfGenericsCheck = File.ReadAllText(filePath);

        //If the listOfGenericsCheck contains data. 
        if (!string.IsNullOrWhiteSpace(listOfGenericsCheck))
            //Deserialize the JSON string into a list. If the deserialization fails it will not change the value of the input list.
            listOfGenerics = JsonSerializer.Deserialize<List<T>>(listOfGenericsCheck) ?? listOfGenerics;

        //If listOfGenerics contains objects it will print the type of the objects and confirm that they are loaded.
        if (listOfGenerics.Count > 0)
            Console.WriteLine($"{typeof(T).Name}s loaded from file.");
        else
            //If the listOfGenerics does not contain any objects it will print that the file contains no objects.
            Console.WriteLine($"The file contains no {typeof(T).Name}s.");
    }

    //Generic method to save JSON files.
    public static void JsonSaveGeneric<T>(List<T> listOfGenerics, string filePath)
    {   //Check if the file exists.
        if (!JsonFileExists(filePath)) return;
        //Serialize the list into a JSON string and indents it. Then writes the JSON string to the file.
        string jsonString = JsonSerializer.Serialize(listOfGenerics, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);

        Console.WriteLine($"{typeof(T).Name} file updated.");
    }

    //Old method to save JSON books.
    // public static void JsonSaveLibrary(List<Book> listOfBooks, string filePath)
    // {
    //     if (!JsonFileExists(filePath)) return;

    //     string jsonString = JsonSerializer.Serialize(listOfBooks, new JsonSerializerOptions { WriteIndented = true });
    //     File.WriteAllText(filePath, jsonString);
    //     Console.WriteLine("Library updated.");
}