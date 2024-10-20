/*
 * Lexicographic permutations:
 *  permutations listed numerically or alphabetically
 * 
 * What is the millionth lexicographic permutation of the digits
 *  0, 1, 2, 3, 4, 5, 6, 7, 8, 9?
 */

namespace _24_Lexicographic_Permutations;

class Program
{
    static void Main()
    {
        int[] digits = CreateDigitArray(0,9);
        int LEN = digits.Length;
        int i, j, temp;

        for (int count = 1; count < 1000000; count++) // up to the millionth permutation
        {
            for (i = LEN - 1; i > 0 && digits[i - 1] >= digits[i]; i--) ; // finds the largest index i such that digits[i-1] < digits[i]
            for (j = LEN - 1; j > 0 && digits[j] <= digits[i - 1]; j--) ; // finds the largest index j such that digits[j] > digits[j-1]

            // swaps digits[i - 1] and digits[j]
            temp = digits[i - 1];
            digits[i - 1] = digits[j];
            digits[j] = temp;

            // reverses digits to find next lexicographical permutation
            for (j = LEN - 1; i < j; i++, j--)
            {
                temp = digits[i];
                digits[i] = digits[j];
                digits[j] = temp;
            }
        }

        foreach (var digit in digits)
        {
            Console.Write(digit);
        }
        
        // O(n) time complexity (took me a solid bit of thinking to get to this gahdamn)
    }

    static int[] CreateDigitArray(int min, int max)
    {
        var array = new int[max-min+1];
        int j = 0;
        for (int i = min; i <= max; i++)
        {
            array[j] = i;
            j++;
        }

        return array;
    }
}
