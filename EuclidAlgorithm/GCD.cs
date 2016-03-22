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

        #region Algorithms

        /// <summary>
        /// Count GCD by Euclid Algorithm for two numbers. 
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common denominator</returns>
        public static int EuclidAlgorithm(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

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
        public static int SteinAlgorithm(int a, int b)
        {

            if (a == 0 || b == 0)
                return a == 0 ? a : b;
            if (a == b)
                return a;
            if (a == 1 || b == 1)
                return 1;
            if (IsEven(a) && IsEven(b))
                return SteinAlgorithm(a / 2, b / 2);
            if (IsEven(a) && !IsEven(b))
                return SteinAlgorithm(a / 2, b);
            if (!IsEven(a) && IsEven(b))
                return SteinAlgorithm(a, b / 2);
            if (!IsEven(a) && !IsEven(b) && a < b)
                return SteinAlgorithm((b - a) / 2, a);
            if (!IsEven(a) && !IsEven(b) && a > b)
                return SteinAlgorithm((a - b) / 2, b);
            return 0;
        }

        #endregion

        /// <summary>
        /// Count GCD for 2 arguments
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="time">double value for time</param>
        /// <param name="Function">Algorithm</param>
        /// <returns>The greatets common denominator</returns>
        public static int CountGCD(int a, int b, out double time, Func<int, int, int> Function)
        {
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = Count(a, b, Function);
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// Count GCD for 3 arguments
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <param name="time">double value for time</param>
        /// <param name="Function">Algorithm</param>
        /// <returns>The greatets common denominator</returns>
        public static int CountGCD(int a, int b, int c, out double time, Func<int, int, int> Function)
        {
            int result = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            result = Count(a, b, Function);
            result = Count(result, c, Function);
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// Count GCD for 1 or more than 3  arguments
        /// </summary>
        /// <param name="time">double value for time</param>
        /// <param name="Function">Algorithm</param>
        /// <param name="array">numbers</param>
        /// <returns>The greatets common denominator</returns>
        public static int CountGCD(out double time, Func<int, int, int> Function, params int[] array)
        {
            int gcd = array[0];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < array.Length; i++)
                gcd = Count(gcd, array[i], Function);
            sw.Stop();
            time = sw.Elapsed.TotalMilliseconds;
            return gcd;
         }

        /// <summary>
        /// Count GCD for 3 arguments
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="c">third number</param>
        /// <param name="time">double value for time</param>
        /// <returns>The greatets common denominator</returns>
        public static int CountGCD(int a, int b, int c, out double time)
        {
            return CountGCD(a, b, c, out time, null);
        }

        /// <summary>
        /// Count GCD for 2 arguments
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <param name="time">double value for time</param>
        /// <returns>The greatets common denominator</returns>
        public static int CountGCD(int a, int b, out double time)
        {
            return CountGCD(a, b, out time, null);
        }

        /// <summary>
        /// Count GCD for 1 or more than 3  arguments
        /// </summary>
        /// <param name="time">double value for time</param>
        /// <param name="array">numbers</param>
        /// <returns>The greatets common denominator</returns>
        public static int CountGCD(out double time, params int[] array)
        {
            return CountGCD(out time, null, array);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Count GCD without time
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="Function">Method of counting</param>
        /// <returns>The greatest common denominator</returns>
        private static int Count(int a, int b, Func<int, int, int> Function)
        {
            if (Function == null)
                Function = EuclidAlgorithm;
            a = Math.Abs(a);
            b = Math.Abs(b);
            int result = Function(a, b);
            return result;
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
