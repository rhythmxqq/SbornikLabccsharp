﻿using System;

class Program
{
    static void Main()
    {
        int[] sequence = new int[1000];

        // Заполнение последовательности случайными числами от 1 до 10000
        Random random = new Random();
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = random.Next(1, 10001);
        }

        int result = FindMaxR(sequence);
        Console.WriteLine("Результат: " + result);
    }

    static int FindMaxR(int[] sequence)
    {
        int maxR = -1;

        for (int i = 0; i < sequence.Length - 1; i++)
        {
            for (int j = i + 1; j < sequence.Length; j++)
            {
                int product = sequence[i] * sequence[j];

                if (product < 10000 && product % 14 == 0 && product > maxR)
                {
                    maxR = product;
                }
            }
        }

        return maxR;
    }
}
