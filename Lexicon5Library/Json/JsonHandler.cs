using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lexicon5Library.Json;

internal static class JsonHandler
{
    private readonly static string jsonFilePath = @"C:\Lexicon kod\LexiconUppgifter\Lexicon5Library\Lexicon5Library\Json\LibraryJSON.json";

    private static bool JsonFileExists()
    {
        if (File.Exists(jsonFilePath))
        {
            return true;
        }
        else
        {
            Console.WriteLine("File not found...");
            return false;
        }
    }

    public static void JsonLoadLibrary(ref List<Book> listOfBooks)
    {
        if (!JsonFileExists())
            return;

        listOfBooks = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(jsonFilePath)) ?? listOfBooks;

        if (listOfBooks.Count > 0)
            Console.WriteLine("Library loaded.");
        else
            Console.WriteLine("Library is empty.");
    }

    public static void JsonSaveLibrary(List<Book> listOfBooks)
    {
        if (!JsonFileExists()) return;

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(listOfBooks, options);
        File.WriteAllText(jsonFilePath, jsonString);
        Console.WriteLine("Library updated.");
    }
}