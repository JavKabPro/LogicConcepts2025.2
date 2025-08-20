using Shared;
do
{
    var a = ConsoleExtension.GetInt("Ingrese el primer número: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo número: ");
    if (b % a == 0)
    {
        Console.WriteLine($"{a} es múltiplo de {b}");
    }
    else
    {
        Console.WriteLine($"{a} No es múltiplo de {b}");
    }
} while (true);
