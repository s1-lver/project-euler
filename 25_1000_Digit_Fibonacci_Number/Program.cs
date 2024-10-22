/*
 * Fibonacci sequence: F(n) = F(n-1) + F(n-2) where F(1) = 1 and F(2) = 1
 * find the index of the first item in the fibonacci sequence to contain 1000 digits
 */

using System.Numerics;

namespace _25_1000_Digit_Fibonacci_Number;

class Program
{
    static void Main()
    {
        Console.WriteLine(HugeFibonacciIndex(BigInteger.Zero,BigInteger.One,1000));
    }

    static int HugeFibonacciIndex(BigInteger prevFibonacci, BigInteger fibonacci, int digits)
    {
        int index = 1;
        while (fibonacci.ToString().Length < digits)
        {
            var temp = fibonacci;
            fibonacci = prevFibonacci + fibonacci;
            prevFibonacci = temp;

            index++;
        }

        return index;
    }
}