/*
 * Find the value of d < 1000 for which 1/d contains the longest recurring
 *  cycle in its decimal fraction part
 *
 * -- you can do long division until you get the same remainder back, once you do then you know
 *  it recurs at that point. If we get zero, it's not a recurring decimal.
 */

namespace _26_Reciprocal_Cycles;

class Program
{
    static void Main()
    {
        int[] max = new int [2] {0, 0};
        for (int i = 1; i <= 1000; i++)
        {
            int len = RecurringLength(i);
            if (len > max[1])
            {
                max[0] = i;
                max[1] = len;
            }
        }

        Console.WriteLine(max[0]);
    }

    static int RecurringLength(int d)
    {
        int numerator = 10;
        var digits = new List<int>();
        var remainders = new List<int>();
        int cur = numerator;
        while (true)
        {
            int digit = cur / d;
            cur %= d;
            if (remainders.Contains(cur))
            {
                break;
            }
            digits.Add(digit);
            remainders.Add(cur);
            cur *= 10;
            if (cur == 0)
            {
                return 0;
            }

            while (cur < d)
            {
                cur *= 10;
                digits.Append(0);
            }
        }

        while (remainders[0] != cur)
        {
            remainders.RemoveAt(0);
        }

        return remainders.Count;
    }
    
}