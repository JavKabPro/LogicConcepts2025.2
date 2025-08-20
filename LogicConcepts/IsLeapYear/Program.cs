using Shared;
do
{
    var currentYear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese el año pa ver: ");
    if (year == currentYear)
    {
        message = "es";
    }
    else if (year > currentYear)
    {
        message = "va a ser";
    }
    else
    {
        message = "fue";
    }

    if (year % 4 == 0)
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
            {
                Console.WriteLine($"{year} SI {message} bisiesto");
            }
            else
            {
                Console.WriteLine($"{year} NO {message} bisiesto");
            }
        }
        else
        {
            Console.WriteLine($"{year} SI {message} bisiesto");
        }
    }
    else
    {
        Console.WriteLine($"{year} NO {message} bisiesto");
    }
} while (true);
