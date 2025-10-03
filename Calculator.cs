namespace ConsoleCalculator;

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
