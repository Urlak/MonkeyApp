using System;
using System.Threading.Tasks;

namespace MyMonkeyApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================ Monkey App ================");
            Console.WriteLine("1) List all monkeys");
            Console.WriteLine("2) Get details for a specific monkey by name");
            Console.WriteLine("3) Get a random monkey");
            Console.WriteLine("4) Exit");
            Console.WriteLine("============================================");
            Console.Write("Select an option: ");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    await ListAllMonkeys();
                    break;
                case "2":
                    await GetMonkeyByName();
                    break;
                case "3":
                    await GetRandomMonkey();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static async Task ListAllMonkeys()
    {
        var monkeys = await MonkeyHelper.GetMonkeysAsync();
        Console.WriteLine("\nAvailable Monkeys:");
        Console.WriteLine("---------------------------------------------------------------------------------------------");
        Console.WriteLine($"| {"Name",-20} | {"Location",-25} | {"Population",-10} | {"Access Count",-12} |");
        Console.WriteLine("---------------------------------------------------------------------------------------------");
        foreach (var monkey in monkeys)
        {
            Console.WriteLine($"| {monkey.Name,-20} | {monkey.Location,-25} | {monkey.Population,-10} | {MonkeyHelper.GetRandomMonkeyAccessCount(),-12} |");
        }
        Console.WriteLine("---------------------------------------------------------------------------------------------");
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    private static async Task GetMonkeyByName()
    {
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine();
        var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name ?? string.Empty);
        if (monkey == null)
        {
            Console.WriteLine($"Monkey '{name}' not found.");
        }
        else
        {
            ShowMonkeyDetails(monkey);
        }
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    private static async Task GetRandomMonkey()
    {
        var monkey = await MonkeyHelper.GetRandomMonkeyAsync();
        if (monkey == null)
        {
            Console.WriteLine("No monkeys available.");
        }
        else
        {
            ShowMonkeyDetails(monkey);
            Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
        }
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    private static void ShowMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine("\n  .-\"\"\"\"-.   ");
        Console.WriteLine(" / -   -  \");
        Console.WriteLine(" |  o   o  |");
        Console.WriteLine(" |    ^    |");
        Console.WriteLine(" |  '-'    |");
        Console.WriteLine("  \\       /");
        Console.WriteLine("  '-----'");
        Console.WriteLine($"Name: {monkey.Name}");
        Console.WriteLine($"Location: {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population}");
        Console.WriteLine($"Latitude: {monkey.Latitude}");
        Console.WriteLine($"Longitude: {monkey.Longitude}");
        Console.WriteLine($"Details: {monkey.Details}");
        Console.WriteLine($"Image: {monkey.Image}");
    }
}
