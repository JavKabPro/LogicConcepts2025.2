using Shared;
var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var a = ConsoleExtension.GetDouble("Digita el valor de a: ");
    var b = ConsoleExtension.GetDouble("Digita el valor de b: ");
    var c = ConsoleExtension.GetDouble("Digita el valor de c: ");
    var solution = QuadraticEquation(a, b, c);
    Console.WriteLine($"x1 = {solution.X1:N5}");
    Console.WriteLine($"x2 = {solution.X2:N5}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

QuadraticEquationsolution QuadraticEquation(double a, double b, double c)
{
    return new QuadraticEquationsolution
    {
        X1 = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a),
        X2 = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a)
    };
}

Console.WriteLine("Game Over.");

public class QuadraticEquationsolution
{
    public double X1 { get; set; }
    public double X2 { get; set; }
}