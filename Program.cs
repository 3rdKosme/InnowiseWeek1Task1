using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator;

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