using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Fibonacci LFSR simulation");
            Console.WriteLine("Polynominal? (n bits ex. : 101001 -> 1 + x^2 + x^5)");
            String poly = Console.ReadLine();
            List<int> Poly = new List<int>();

            for (int i = 0; i < poly.Length; i++)
            {
                Poly.Add(Int32.Parse(poly[i].ToString()));
            }

            Console.WriteLine("Seed? (n-1 bits)");
            String seed = Console.ReadLine();
            List<int> Seed = new List<int>();
            Console.WriteLine();

            for (int i = 0; i < seed.Length; i++)
            {
                Seed.Add(Int32.Parse(seed[i].ToString()));
            }

            List<int> Current = new List<int>(Seed);
            List<int> Next = new List<int>(Seed);
            List<Int16> Out = new List<Int16>(); //output on the rightmost (x^5) flip flop for other uses
            List<List<int>> History = new List<List<int>>();
            int ones = 0;
            for (int k = 0; k < Math.Pow(2, Current.Count) - 1; k++)
            {
                for (int i = 0; i < Current.Count; i++)
                {
                    if (Poly[i + 1] == 1 && Current[i] == 1)
                    {
                        ones++;
                    }
                }
                if (ones % 2 == 1)
                {
                    Next[0] = 1;
                }
                else
                {
                    Next[0] = 0;
                }
                ones = 0;
                for (int i = 1; i < Current.Count; i++)
                {
                    Next[i] = Current[i - 1];
                }
                Out.Add((Int16)Current[Current.Count - 1]);
                if (Current.IsIn(History))
                {
                    Console.WriteLine("Found a cycle shorter than 2^n-1 therefore its not primal poly. Cycle length with given seed is: " + History.Count);
                    break;
                }

                History.Add(Current);
                Current.ForEach(Console.Write);
                Console.WriteLine();
                Current = new List<int>(Next);
                if (k == Math.Pow(2, Current.Count) - 2)
                    Console.Write("Poly is primal");
            }
            Console.ReadLine();
        }
    }
}

public static class ListExt
{
    public static bool IsIn<T>(this List<T> item, List<List<T>> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].SequenceEqual(item))
                return true;
        }
        return false;
    }
}
