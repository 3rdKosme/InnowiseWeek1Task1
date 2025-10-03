namespace ConsoleCalculator;

class InputHelper
{
    public static bool TryGetNumber(string prompt, out double number)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if(double.TryParse(input, out number))
        {
            return true;
        }

        Console.WriteLine("Ошибка: Введено некорректное число!\n");
        return false;
    }

    public static bool TryGetOperation(out Operation operation)
    {
        Console.Write($"Выберите операцию ({Calculator.GetAvailableOperations()}): ");
        string? input = Console.ReadLine();

        if(Calculator.IsValidOperation(input, out operation))
        {
            return true;
        }

        Console.WriteLine($"Ошибка: Неверная операция! Используйте {Calculator.GetAvailableOperations()}\n");
        return false;
    }

    public static bool AskToContinue()
    {
        Console.WriteLine("\nВыберите дальнейшее действие: ");
        Console.WriteLine("1. Продолжить использование калькулятора\n2. Выйти\n");
        string? answer = Console.ReadLine();
        if (answer == "1")
        {
            Console.WriteLine();
            return true;
        }
        else
        {
            Console.WriteLine("Спасибо за использование калькулятора!");
            return false;
        }
    }
}
