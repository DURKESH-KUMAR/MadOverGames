using System;

public class TripletSum
{
    public static bool IsSumThreeZero(int[] a)
    {
        Array.Sort(a);

        for (int i = 0; i < a.Length - 2; i++)
        {
            int left = i + 1;
            int right = a.Length - 1;

            while (left < right)
            {
                int sum = a[i] + a[left] + a[right];

                if (sum == 0)
                    return true;
                else if (sum < 0)
                    left++;
                else
                    right--;
            }
        }

        return false;
    }
}