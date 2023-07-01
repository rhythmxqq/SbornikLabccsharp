using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ведите количество смс");
        // Ввод количества sms-сообщений
        int N = int.Parse(Console.ReadLine());

        // Словарь для хранения количества голосов для каждой пары
        Dictionary<int, int> voteCount = new Dictionary<int, int>();

        // Обработка результатов голосования
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("Ведите № команды");
            int pairNumber = int.Parse(Console.ReadLine());

            if (voteCount.ContainsKey(pairNumber))
            {
                voteCount[pairNumber]++;
            }
            else
            {
                voteCount[pairNumber] = 1;
            }
        }

        // Создание списка всех пар (от 1 до 16)
        List<int> allPairs = Enumerable.Range(1, 16).ToList();

        // Добавление пар без голосов в словарь с нулевым количеством голосов
        foreach (int pair in allPairs)
        {
            if (!voteCount.ContainsKey(pair))
            {
                voteCount[pair] = 0;
            }
        }

        // Сортировка пар по убыванию количества голосов
        List<KeyValuePair<int, int>> sortedPairs = voteCount.OrderByDescending(x => x.Value).ToList();

        // Вывод результатов
        foreach (var pair in sortedPairs)
        {
            Console.WriteLine(pair.Key + " " + pair.Value);
        }
    }
}
