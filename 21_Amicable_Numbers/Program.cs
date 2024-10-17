/*
 * Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n
 * If d(a) = b and d(b) = a, where a =/= b, then a and b are an amicable pair and each of
 *  a and b are called amicable numbers
 * For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110;
 *  therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so
 * d(284) = 220
 */

using System.Runtime.InteropServices.JavaScript;

namespace _21_Amicable_Numbers;

class Program
{
    static void Main(string[] args)
    {
        var amicableNums = new List<int>();
        for (int i = 1; i < 10000; i++)
        {
            if (IsAmicable(i))
            {
                amicableNums.Add(i);
            }
        }
        Console.WriteLine(amicableNums.Sum());
    }

    static List<int> GetDivisors(int number)
    {
        var divisors = new List<int>();
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                divisors.Add(i);
            }
        }
        return divisors;
    }

    static int SumDivisors(List<int> divisors)
    {
        return divisors.Sum();
    }

    static bool IsAmicable(int number)
    {
        int a = number;
        int b = SumDivisors(GetDivisors(number));

        if (a == SumDivisors(GetDivisors(b)) && a != b)
        {
            return true;
        }

        return false;
    }
}