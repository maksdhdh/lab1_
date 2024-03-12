using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<string> keys = new List<string>() { "key1", "key2", "key3" };
        List<int> values = new List<int>() { 1, 2, 3 };

        Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();

        for (int i = 0; i < keys.Count; i++)
        {
            dictionary[keys[i]] = new List<int>();
            dictionary[keys[i]].Add(values[i]);
        }

        Console.WriteLine("Dictionary:");
        foreach (var pair in dictionary)
        {
            Console.WriteLine($"{pair.Key}: [{string.Join(", ", pair.Value)}]");
        }
        string json = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("dictionary.json", json);

        Console.WriteLine("Dictionary saved to dictionary.json");

        Console.ReadLine();
    }
}

