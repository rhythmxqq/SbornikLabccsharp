using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filename = "/Users/mak/Projects/lab3fxqcsharp/lab3fxqcsharp/17-342.txt";
        int count = CountPairs(filename);
        int minSum = GetMinSum(filename);

        Console.WriteLine("Количество пар: " + count);
        Console.WriteLine("Минимальная сумма элементов: " + minSum);
    }

    static int CountPairs(string filename)
    {
        int count = 0;
        int previousNum = 0;
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int currentNum = int.Parse(line);

                if (IsWithinRange(previousNum, currentNum))
                {
                    count++;
                }

                previousNum = currentNum;
            }
        }
        return count;
    }

    static int GetMinSum(string filename)
    {
        int minSum = int.MaxValue;
        int previousNum = 0;
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int currentNum = int.Parse(line);

                if (IsWithinRange(previousNum, currentNum))
                {
                    int sum = previousNum + currentNum;
                    minSum = Math.Min(minSum, sum);
                }

                previousNum = currentNum;
            }
        }
        return minSum;
    }

    static bool IsWithinRange(int num1, int num2)
    {
        int minMultiple37 = GetMinMultiple(37);
        int maxMultiple73 = GetMaxMultiple(73);
        return (num1 > minMultiple37 && num2 < maxMultiple73) || (num1 < maxMultiple73 && num2 > minMultiple37);
    }

    static int GetMinMultiple(int number)
    {
        return (int)Math.Ceiling(10000.0 / number) * number;
    }

    static int GetMaxMultiple(int number)
    {
        return (int)Math.Floor(10000.0 / number) * number;
    }
}
