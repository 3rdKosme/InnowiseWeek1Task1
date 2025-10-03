using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator;


enum Operation
{
    Add,
    Substract,
    Multiply,
    Divide
}

class Calculator
{
    public static readonly Dictionary<string, Operation> OperationMap = new Dictionary<string, Operation>
    {
        { "+", Operation.Add },
        { "-", Operation.Substract },
        { "*", Operation.Multiply },
        { "/", Operation.Divide }
    };

    public static string GetAvailableOperations()
    {
        return string.Join(", ", OperationMap.Keys);
    }

    public static bool IsValidOperation(string operation, out Operation result)
    {
        return OperationMap.TryGetValue(operation, out result);
    }

    public static bool Calculate(double num1, Operation operation, double num2, out double result, out string? errorMessage)
    {
        result = 0;
        errorMessage = null;

        switch (operation)
        {
            case Operation.Add:
                result = num1 + num2;
                return true;
            case Operation.Substract:
                result = num1 - num2;
                return true;
            case Operation.Multiply:
                result = num1 * num2;
                return true;
            case Operation.Divide:
                if (num2 != 0)
                {
                    result = num1 / num2;
                    return true;
                }
                else
                {
                    errorMessage = "Деление на ноль!";
                    return false;
                }    
            default:
                errorMessage = "Введена непредвиденная операция";
                return false;
        }
    }
}

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
class Program
{

    static void Main(string[] args)
    {
        bool continueCalculating = true;

        Console.WriteLine("=== Консольный калькулятор ===");

        while (continueCalculating)
        {
            try
            {
                if (!InputHelper.TryGetNumber("Введите первое число: ", out double num1)) 
                    continue;

                if (!InputHelper.TryGetOperation(out Operation operation))
                    continue;

                if (!InputHelper.TryGetNumber("Введите второе число: ", out double num2))
                    continue;

                if(Calculator.Calculate(num1, operation, num2, out double result, out string? errorMessage))
                {
                    string operationSymbol = Calculator.OperationMap.FirstOrDefault(x => x.Value == operation).Key ?? "?";
                    Console.WriteLine($"\nРезультат: {num1} {operationSymbol} {num2} = {result}\n");
                }
                else
                {
                    Console.WriteLine($"Ошибка: {errorMessage}\n");
                }

                continueCalculating = InputHelper.AskToContinue();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: Возникло непредвиденное исключение: " + ex.Message);
            }
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}