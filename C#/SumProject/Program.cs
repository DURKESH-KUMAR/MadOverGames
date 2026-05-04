using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr1 = { -7, -5, 4, 5, 6 };
        int[] arr2 = { -7, -3, 4, 6, 10, 15 };
        int[] arr3 = { -11, 5, 6, 11 };

        Console.WriteLine("=== Pair Sum ===");
        Console.WriteLine($"arr1: {PairSum.IsSumTwoZero(arr1)}"); // True
        Console.WriteLine($"arr2: {PairSum.IsSumTwoZero(arr2)}"); // False
        Console.WriteLine($"arr3: {PairSum.IsSumTwoZero(arr3)}"); // True

        Console.WriteLine("\n=== Triplet Sum ===");
        Console.WriteLine($"arr1: {TripletSum.IsSumThreeZero(arr1)}"); // False
        Console.WriteLine($"arr2: {TripletSum.IsSumThreeZero(arr2)}"); // True
        Console.WriteLine($"arr3: {TripletSum.IsSumThreeZero(arr3)}"); // True
    }
}