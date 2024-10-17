/*
 * n! means n * (n-1) * ... * 3 * 2 * 1
 * For example, 10! = 10 * 9 * ... * 3 * 2 * 1 = 3628800
 * and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27
 *
 * Find the sum of the digits in the number 100!
 */

using System.Numerics;

namespace _20_Factorial_Digit_Sum;
class Program
{
    static void Main()
    {
        var numFact = Factorial(100).ToString();
        int sum = 0;
        foreach (var digit in numFact)
        {
            sum += (int) Char.GetNumericValue(digit);
        }

        Console.WriteLine(sum);
    }

    static BigInteger Factorial(BigInteger number)
    {
        if (number == 1)
        {
            return 1;
        }
        return number * Factorial(number - 1);
    }
} 