﻿using Shared;
var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuántos números desea: ");
    int sum = 0;
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i}\t");
        sum += i;
    }
    decimal average = n > 0 ? (decimal)sum / n : 0m;
    Console.WriteLine();
    Console.WriteLine($"\nLa suma es....: {sum,20:N0}");
    Console.WriteLine($"\nEl promedio es: {average,20:N2}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");