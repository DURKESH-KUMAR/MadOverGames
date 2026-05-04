using System.Collections.Generic;

public class PairSum
{
    public static bool IsSumTwoZero(int[] a)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in a)
        {
            if (set.Contains(-num))
                return true;

            set.Add(num);
        }

        return false;
    }
}