using Lexicon5Library.Library;
using System.Text.Json;
namespace Lexicon5Library.Json;

internal static class JsonHandler
{
    public const string jsonFilePath = @"Json\LibraryJSON.json";

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

    //Work in progress
    public static void JsonLoadGeneric<T>(ref List<T> listOfGenerics, string filePath)
    {
        if (!JsonFileExists(filePath)) return;

        var listOfGenericsCheck = File.ReadAllText(filePath);

        if (!string.IsNullOrWhiteSpace(listOfGenericsCheck))
            listOfGenerics = JsonSerializer.Deserialize<List<T>>(listOfGenericsCheck) ?? listOfGenerics;

        if (listOfGenerics.Count > 0)
            Console.WriteLine($"{typeof(T).Name}s loaded from file.");
        else
            Console.WriteLine($"The file contains no {typeof(T).Name}s.");
    }

    public static void JsonSaveGeneric<T>(List<T> listOfGenerics, string filePath)
    {
        if (!JsonFileExists(filePath)) return;

        string jsonString = JsonSerializer.Serialize(listOfGenerics, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine($"{typeof(T).Name} file updated.");
    }

    public static void JsonSaveLibrary(List<Book> listOfBooks, string filePath)
    {
        if (!JsonFileExists(filePath)) return;

        string jsonString = JsonSerializer.Serialize(listOfBooks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Library updated.");
    }
}