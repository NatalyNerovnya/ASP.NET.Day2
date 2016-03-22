using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuclidAndStainAlgorithm;

namespace EuclidAndStainAlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 26, b = 3, c = 2;
            double time;
            Console.WriteLine($"GCD({a}, {b}) = {GCD.CountGCD(a, b, out time, GCD.EuclidAlgorithm)} - Euclid, required time - {time};");
            Console.WriteLine($"GCD({a}, {b}) = {GCD.CountGCD(a, b, out time, GCD.SteinAlgorithm)} - Stein, required time - {time};");

            Console.WriteLine($"GCD({a}, {b}, {c}) = {GCD.CountGCD(a, b, c, out time)} - Euclid, required time - {time};");
            Console.WriteLine($"GCD({a}, {b}, {c}) = {GCD.CountGCD(a, b, c, out time, GCD.SteinAlgorithm)} - Stein, required time - {time};");

            Console.WriteLine($"GCD(8, -4, 12, 16, -32) = {GCD.CountGCD(out time, 8, -4, 12, 16, -32)} - Euclid, required time - {time};");
            Console.WriteLine($"GCD(27, -3, 12, 15, -33) = {GCD.CountGCD(out time, GCD.SteinAlgorithm, 27, -3, 12, 15, -33)} - Stein, required time - {time};");

            Console.ReadLine();
        }
    }
}
