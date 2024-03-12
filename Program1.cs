//У файлі збережено адреси. Побудувати список C1,
//елементи якого містять назву вулиці та індекси даних адрес,
//причому елементи списку повинні бути впорядковані за зростанням індексів.
//Потім "стиснути" список C1, видаляючи дублюючі назви об'єктів

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program2
{
    static void Main(string[] args)
    {
        List<string> addresses = ReadAddressesFromFile("addresses.txt");
        List<Tuple<string, int>> C1 = BuildC1List(addresses);
        C1.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        List<Tuple<string, int>> compressedC1 = CompressC1List(C1);
        foreach (var item in compressedC1)
        {
            Console.WriteLine($"{item.Item1}: {item.Item2}");
        }
    }

    static List<string> ReadAddressesFromFile(string filename)
    {
        List<string> addresses = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    addresses.Add(line.Trim());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading addresses from file: {e.Message}");
        }
        return addresses;
    }

    static List<Tuple<string, int>> BuildC1List(List<string> addresses)
    {
        List<Tuple<string, int>> C1 = new List<Tuple<string, int>>();
        for (int i = 0; i < addresses.Count; i++)
        {
            string[] parts = addresses[i].Split(',');
            string streetName = parts[0].Trim();
            C1.Add(new Tuple<string, int>(streetName, i));
        }
        return C1;
    }

    static List<Tuple<string, int>> CompressC1List(List<Tuple<string, int>> C1)
    {
        List<Tuple<string, int>> compressedC1 = new List<Tuple<string, int>>();
        HashSet<string> uniqueNames = new HashSet<string>();

        foreach (var item in C1)
        {
            if (!uniqueNames.Contains(item.Item1))
            {
                uniqueNames.Add(item.Item1);
                compressedC1.Add(item);
            }
        }
        return compressedC1;
    }
}
