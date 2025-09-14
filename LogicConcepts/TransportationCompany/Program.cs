using Shared;
var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
   
    var routeOptions = new List<string> { "1", "2", "3","4" };
    var route = string.Empty;
    do
    {
        route = ConsoleExtension.GetValidOptions("Ruta [1][2][3][4].........................: ", routeOptions);
    } while (!routeOptions.Any(x => x == route));

    var trips = ConsoleExtension.GetInt("Número de viajes.............................: ");
    var passengers = ConsoleExtension.GetInt("Número de pasajeros total.....................: ");
    var packages10 = ConsoleExtension.GetInt("Número de paquetes de menos de 10kg...................: ");
    var packages10_20 = ConsoleExtension.GetInt("Número de paquetes de entre 10kg y 20 Kg.................: ");
    var packages20 = ConsoleExtension.GetInt("Número de paquetes de menos de 20kg...................: ");

    // Calculations
    var incomePassengers = GetIncomePassangers(route, passengers, trips);
    var incomePackages = GetIncomePackages(route, packages10, packages10_20, packages20);
    var incomes = incomePassengers + incomePackages;
    var valueHleper =  GetValueHelper(incomes);
    var valueAssurance = GetValueAssurance(incomes);
    var valueFuel = GetValueFuel(route, trips, passengers, packages10, packages10_20, packages20);
    var deductions = valueHleper + valueAssurance + valueFuel;
    var valueTotalToPay = incomes - deductions;

    Console.WriteLine("***  RESULTADOS  ***");
    Console.WriteLine($"Ingresos por Pasajeros..................................: {incomePassengers,20:C2}");
    Console.WriteLine($"Ingresos por Paquetes...................................: {incomePackages,20:C2}");
    Console.WriteLine($"                                                          --------------------");
    Console.WriteLine($"TOTAL INGRESOS..........................................: {incomes,20:C2}");
    Console.WriteLine($"Pago Auxiliar...........................................: {valueHleper,20:C2}");
    Console.WriteLine($"Pago Seguro.............................................: {valueAssurance,20:C2}");
    Console.WriteLine($"Pago Combustible........................................: {valueFuel,20:C2}");
    Console.WriteLine($"                                                          --------------------");
    Console.WriteLine($"TOTAL DEDUCCIONES.......................................: {deductions,20:C2}");
    Console.WriteLine($"                                                          ====================");
    Console.WriteLine($"VALOR TOTAL A LIQUIDAR..................................: {valueTotalToPay,20:C2}");



    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal GetValueFuel(string? route, int trips, int passengers, int packages10, int packages10_20, int packages20)
{
    float kms = 0;
    switch (route)
    {
        case "1":
            kms = 150 * trips;
            break;
        case "2":
            kms = 167 * trips;
            break;
        case "3":
            kms = 184 * trips;
            break;
        default:
            kms = 203 * trips;
            break;
    }
    var gallons = kms / 39;
    var value = (decimal)gallons * 8860m;
    var weight = passengers * 60 + packages10 * 10 + packages10_20 * 15 + packages20 * 20;
    if (weight < 5000) return value;
    if (weight <= 10000) return value * 1.1m;
    return value * 1.25m;
}
    decimal GetValueAssurance(decimal incomes)
{
    if (incomes < 1000000) return incomes * 0.03m;
    if (incomes < 2000000) return incomes * 0.04m;
    if (incomes < 4000000) return incomes * 0.06m;
    return incomes * 0.9m;
}

decimal GetValueHelper(decimal incomes)
{
    if (incomes < 1000000) return incomes * 0.05m;
    if (incomes < 2000000) return incomes * 0.08m;
    if (incomes < 4000000) return incomes * 0.1m;
    return incomes * 0.13m;
}


Console.WriteLine("Game Over.");
decimal GetIncomePackages(string? route, int packages10, int packages10_20, int packages20)
{
    decimal value = 0;
    switch (route)
    {
        case "1":
            value = packages10 * 3000m + packages10_20 * 5000m + packages20 * 7000m;
            return value;
        case "2":
            if (packages10 <= 50) value += packages10 * 100;
            else if (packages10 <= 100) value += packages10 * 120;
            else if (packages10 <= 130) value += packages10 * 150;
            else value += packages10 * 160;

            var packagesGreather10 = packages10_20 + packages20;
            if (packagesGreather10 <= 50) value += packagesGreather10 * 120;
            else if (packagesGreather10 <= 100) value += packagesGreather10 * 140;
            else if (packagesGreather10 <= 130) value += packagesGreather10 * 160;
            else value += packagesGreather10 * 160;
            return value;
        default:
            if (packages10 <= 50) value += packages10 * 130;
            else if (packages10 <= 100) value += packages10 * 160;
            else if (packages10 <= 130) value += packages10 * 175;
            else value += packages10 * 200;

            if (packages20 <= 50) value += packages20 * 170;
            else if (packages20 <= 100) value += packages20 * 210;
            else if (packages20 <= 130) value += packages20 * 250;
            else value += packages20 * 300;
            return value;
    }
}

decimal GetIncomePassangers(string? route, int passengers, int trips)
{
    decimal value;
    switch (route)
    {
        case "1":
            value = 500000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.05m;
            if (passengers <= 150) return value * 1.06m;
            if (passengers <= 200) return value * 1.07m;
            return value * 1.07m + (passengers - 200) * 50m;
        case "2":
            value = 600000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.07m;
            if (passengers <= 150) return value * 1.08m;
            if (passengers <= 200) return value * 1.09m;
            return value * 1.09m + (passengers - 200) * 60m;
        case "3":
            value = 800000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.1m;
            if (passengers <= 150) return value * 1.13m;
            if (passengers <= 200) return value * 1.15m;
            return value * 1.15m + (passengers - 200) * 100m;
        case "4":
            value = 1000000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.125m;
            if (passengers <= 150) return value * 1.15m;
            if (passengers <= 200) return value * 1.17m;
            return value * 1.17m + (passengers - 200) * 150m;
        default:
            return 0;
    }
}
