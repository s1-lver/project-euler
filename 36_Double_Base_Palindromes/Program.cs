/*
 * Find the sum of all numbers, less than one million, which are
 *  palindromic in base 10 and base 2
 * (the palindromic number in either base may not include leading zeroes)
 */

using System.Numerics;

namespace _36_Double_Base_Palindromes;

class Program
{
    static void Main()
    {
        int sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            if (IsPalindromic(i) && IsPalindromic(DecimalToBinary(i)))
            {
                sum += i;
            }
        }

        Console.WriteLine(sum);
    }
    
    // use pointers to check if palindromic
    static bool IsPalindromic(BigInteger number)
    {
        string numString = number.ToString();
        int left = 0, right = numString.Length - 1;
        while (left <= right)
        {
            if (numString[left] != numString[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    static BigInteger DecimalToBinary(int base10)
    {
        if (base10 == 0) return 0;
        string base2 = "";
        while (base10 > 0)
        {
            base2 = base2.Insert(0, (base10 % 2).ToString());
            base10 /= 2;
        }
        
        return BigInteger.Parse(base2);
    }
}