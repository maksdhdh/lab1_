using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = Enumerable.Range(-10, 11);

        bool foundPositive = false;
        foreach (var number in numbers)
        {
            if (number > 0)
            {
                Console.WriteLine(number);
                foundPositive = true;
                break;
            }
        }

        if (!foundPositive)
        {
            Console.WriteLine(0);
        }
    }
}
