using System;

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
                Console.WriteLine("Введите первое число: ");
                string? input1 = Console.ReadLine();

                if (!double.TryParse(input1, out double num1))
                {
                    Console.WriteLine("Ошибка: Введено некорректное число!\n");
                    continue;
                }

                Console.WriteLine("Выберите операцию (+, -, *, /): ");
                string? operation = Console.ReadLine();

                if(operation != "+" && operation != "-" && operation != "*" && operation != "/")
                {
                    Console.WriteLine("Ошибка: Введена некорректная операция!");
                    continue;
                }

                Console.WriteLine("Введите второе число: ");
                string? input2 = Console.ReadLine();

                if (!double.TryParse(input2, out double num2))
                {
                    Console.WriteLine("Ошибка: Введено некорректное число!\n");
                    continue;
                }

                double result = 0;
                bool validOperation = true;

                switch (operation) 
                {
                    case ("+"):
                        result = num1 + num2;
                        break;
                    case ("-"):
                        result = num1 - num2;
                        break;
                    case ("*"):
                        result = num1 * num2;
                        break;
                    case ("/"):
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Деление на ноль!");
                            validOperation = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Ошибка: Введена непредвиденная операция");
                        break;
                }

                if (validOperation) {
                    Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}");
                }
                Console.WriteLine("\nВыберите дальнейшее действие: ");
                Console.WriteLine("1. Продолжить использование калькулятора\n2. Выйти\n");
                string? answer = Console.ReadLine();
                if (answer == "1") {
                    Console.WriteLine();
                }
                else
                {
                    continueCalculating = false;
                    Console.WriteLine("Спасибо за использование калькулятора!");
                }
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