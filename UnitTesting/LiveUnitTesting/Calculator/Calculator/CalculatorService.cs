namespace Calculator;

public class CalculatorService
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        return a / b;
    }
    public double Power(double a, double b) => Math.Pow(a, b);
    public int Modulus(int a, int b) => a % b;
}
