/*
 * A perfect number is a number for which the sum of its proper divisors
 *  is exactly equal to the number
 * 
 * A number n is called deficient if this sum is less than n
 * A number n is called abundant if this sum is more than n
 * 
 * 12 is the smallest abundant number, hence the smallest number that can be
 *  written as the sum of two abundant numbers is 24
 * 
 * All integers > 28123 can be written as the sum of two abundant numbers
 * 
 * Find the sum of all positive integers which CANNOT be written as the
 *  sum of two abundant numbers
 */

using System.Diagnostics;

namespace _23_Non_Abundant_Sums;

class Program
{
    static void Main()
    {
        const int limit = 28123;

        var abundantNums = new List<int>();
        var twoAbNumSum = new HashSet<int>();
        for (int i = 1; i <= limit; i++)
        {
            if (IsAbundant(i))
            {
                abundantNums.Add(i);
            }
        }
        
        for (int i = 0; i < abundantNums.Count; i++)
        {
            for (int j = i; j < abundantNums.Count; j++)
            {
                int sum = abundantNums[i] + abundantNums[j];
                if (sum <= limit)
                {
                    twoAbNumSum.Add(sum);
                }
                else
                {
                    break;
                }
            }
        }

        int totalSum = CreateListIntegers(1, limit).Sum() - twoAbNumSum.Sum();
        Console.WriteLine(totalSum);
        
    }

    static List<int> CreateListIntegers(int min, int max) //from min to max inclusive
    {
        var list = new List<int>();
        for (int i = min; i <= max; i++)
        {
            list.Add(i);
        }

        return list;
    }

    static bool IsAbundant(int number)
    {
        return SumDivisors(number) > number;
    }

    static int SumDivisors(int number)
    {
        if (number < 2) return 0;

        int sum = 1;
        int sqrt = (int)Math.Sqrt(number);

        for (int i = 2; i <= sqrt; i++)
        {
            if (number % i == 0)
            {
                sum += i;
                if (i != number / i)
                {
                    sum += number / i;
                }
            }
        }
        return sum;
    }
}