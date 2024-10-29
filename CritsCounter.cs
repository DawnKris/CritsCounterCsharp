using System;

class Program
{
    static void Main()
    {
        double critChancePercent = 60; // Крит шанс в процентах
        int hitsNumber = 10;    // Количество ударов
        int minCritHits = 9;     // Минимальное количество критов для убийства босса
        int simulationsCount = 10000; // Количество симуляций. Уменьшение приведет к ускорению выполнения, но снизит точность результатов

        double averageRuns = SimulateDungeonRuns(critChancePercent, hitsNumber, minCritHits, simulationsCount);
        Console.WriteLine($"Среднее количество заходов в данж для выполнения условия: {averageRuns}");
    }

    static double SimulateDungeonRuns(double critChancePercent, int hitsNumber, int minCritHits, int simulationsCount)
    {
        Random random = new Random();
        int totalRuns = 0;

        double critChance = critChancePercent / 100.0; // Переводим вероятность в доли (например, 60% -> 0.6)

        for (int numOfCurrentSimulations = 0; numOfCurrentSimulations < simulationsCount; numOfCurrentSimulations++)
        {
            int runs = 0;

            while (true)
            {
                runs++;
                int critHits = 0;

                // Симуляция ударов и подсчет критов
                for (int hit = 0; hit < hitsNumber; hit++)
                {
                    if (random.NextDouble() < critChance)
                    {
                        critHits++;
                    }
                }

                // Проверка, если достигли нужного количества критов
                if (critHits >= minCritHits)
                {
                    break;
                }
            }

            totalRuns += runs;
            // Использовать для вывода промежуточных результатов. Сначала ознакомьтесь с P.S.S в статье
            // Console.WriteLine($"Среднее количество на данный момент: {Math.Round((double)totalRuns / (numOfCurrentSimulations + 1), 3)}");
        }

        // Среднее количество заходов
        return (double)totalRuns / simulationsCount;
    }
}



