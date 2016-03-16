using System;
using System.Diagnostics;

namespace EuclidAndStainAlgorithm
{
    /// <summary>
    /// Class for count GCD by different algorithms
    /// </summary>
    public class GCD
    {
        #region Public Methods

        /// <summary>
        /// Count GCD by Euclid Algorithm for two numbers. In output window you can see required time
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common denominator</returns>
        public static int CountGCDEuclid(int a, int b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = CountGCDEuclidWithoutTime(a, b);
            sw.Stop();
            Debug.WriteLine($"Required time for two numbers by Euclid: {sw.Elapsed}");
            return gcd;
        }

        /// <summary>
        ///  Count GCD by Euclid Algorithm for three numbers. In Output window you can see required time for counting gcd for each couple of values and for all process
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>Greatest common denominator of three numbers</returns>
        public static int CountGCDEuclid(int a, int b, int c)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = CountGCDEuclidWithoutTime(a, b);
            int gcd2 = CountGCDEuclidWithoutTime(gcd, c);
            sw.Stop();
            Debug.WriteLine($"Required time for three numbers by Euclid: {sw.Elapsed}");
            return gcd2;
        }

        /// <summary>
        /// Count GCD by Euclid Algorithm for more than three numbers. In Output window you can see required time for counting gcd for each couple of values and for all values
        /// </summary>
        /// <param name="numbers">Any quantity of integer numbers</param>
        /// <returns>Greatest common denominator of more than three numbers</returns>
        public static int CountGCDEuclid(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            int gcd = numbers[0];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = CountGCDEuclidWithoutTime(gcd, numbers[i]);
            }
            sw.Stop();
            Debug.WriteLine($"Required time for {numbers.Length} numbers by Euclids: {sw.Elapsed}");
            return gcd;
        }

        /// <summary>
        /// Count GCD by Stein Algorithm for two numbers. In Output window you can see required time
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common denominator</returns>
        public static int CountGCDStein(int a, int b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = CountGCDSteinWithoutTime(a, b);
            sw.Stop();
            Debug.WriteLine($"Required time for counting by Stein algorithm: {sw.Elapsed}");
            return result;
        }

        /// <summary>
        /// Count GCD by Stein Algorithm for three numbers. In Output window you can see required time
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>Greatest common denominator</returns>
        public static int CountGCDStein(int a, int b, int c)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result1 = CountGCDSteinWithoutTime(a, b);
            int result2 = CountGCDSteinWithoutTime(result1, b);
            sw.Stop();
            Debug.WriteLine($"Required time for counting of gcd for three numbers by Stein algorithm: {sw.Elapsed}");
            return result2;
        }

        public static int CountGCDStein(params int [] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();

            int gcd = numbers[0];

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < numbers.Length; i++)
            {
                gcd = CountGCDSteinWithoutTime(gcd, numbers[i]);
            }
            sw.Stop();
            Debug.WriteLine($"Required time for counting of gcd for more than three numbers by Stein algorithm: {sw.Elapsed}");
            return gcd;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Count GCD by Euclid Algorithm for two numbers. 
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common denominator</returns>
        private static int CountGCDEuclidWithoutTime(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b)
                Swap(a, b);
            if (a % b == 0)
                return b;

            int rem = -1;
            do
            {
                rem = a % b;
                a = b;
                b = rem;
            } while (a % b != 0);
            return rem;
        }

        /// <summary>
        ///Count GCD by Stein Algorithm for two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common denominator</returns>
        private static int CountGCDSteinWithoutTime(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0 || b == 0)
                return a == 0 ? a : b;
            if (a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
            if (IsEven(a) && IsEven(b))
                return CountGCDSteinWithoutTime(a / 2, b / 2);
            if (IsEven(a) && !IsEven(b))
                return CountGCDSteinWithoutTime(a / 2, b);
            if (!IsEven(a) && IsEven(b))
                return CountGCDSteinWithoutTime(a, b / 2);
            if (!IsEven(a) && !IsEven(b) && a < b)
                return CountGCDSteinWithoutTime((b - a) / 2, a);
            if (!IsEven(a) && !IsEven(b) && a > b)
                return CountGCDSteinWithoutTime((a - b) / 2, b);
            return 0;
        }

        /// <summary>
        /// Check if number is even or not
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True if number is even. In other case - false</returns>
        private static bool IsEven(int number)
        {
            return number % 2 == 0 ? true : false;
        }

        /// <summary>
        /// Change two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        #endregion
    }
}
