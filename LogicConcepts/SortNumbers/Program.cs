using Shared;

do
{
    Console.WriteLine("Ingres tres números diferentes");
    var a = ConsoleExtension.GetInt("Ingrese el primer número: ");
    var b = ConsoleExtension.GetInt("Ingrese el segundo número: ");
    if(a == b)
    {
        Console.WriteLine("El número debe ser diferente vuelva empezar");
        continue;
    }
    var c = ConsoleExtension.GetInt("Ingrese el tercer número: ");
    if (b == c || c == a)
    {
        Console.WriteLine("El número debe ser diferente vuelva a empezar");
        continue;
    }

    if (a > b && a > c)
    {
        if (b > c)
        {
            Console.WriteLine($"El mayor es {a}, el segundo es {b}, el menor es {c}");
        }
        else
        {
            Console.WriteLine($"El mayor es {a}, el segundo es {c}, el menor es {b}");
        }
    }
    else if (b > a && b > c)
    {
        if (a > c)
        {
            Console.WriteLine($"El mayor es {b}, el segundo es {a}, el menor es {c}");
        }
        else
        {
            Console.WriteLine($"El mayor es {b}, el segundo es {c}, el menor es {a}");
        }
    }
    else
    {
        if (a > b)
        {
            Console.WriteLine($"El mayor es {c}, el segundo es {b}, el menor es {a}");
        }
        else
        {
            Console.WriteLine($"El mayor es {c}, el segundo es {b}, el menor es {a}");
        }
    }
} while (true);

