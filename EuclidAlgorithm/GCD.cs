using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidAndStainAlgorithm
{
    /// <summary>
    /// Class for count GCD by different algorithms
    /// </summary>
    public class GCD
    {
        #region Public Methods
        /// <summary>
        /// Count GCD by Euclid Algorithm for two numbers. In Output window you can see required time
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greatest common denominator</returns>
        public static int CountGCDEuclid(int a, int b)
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                rem = a % b;
                a = b;
                b = rem;
            } while (a % b != 0);
            sw.Stop();

            Debug.WriteLine($"Required time for two numbers: {sw.Elapsed}");
            return rem;
        }

        /// <summary>
        ///  Count GCD by Euclid Algorithm for three numbers. In Output window you can see required time for counting gcd for each couple of values
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>Greatest common denominator of three numbers</returns>
        public static int CountGCDEuclid(int a, int b, int c)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int gcd = CountGCDEuclid(a, b);
            int gcd2 = CountGCDEuclid(gcd, c);
            sw.Stop();
            Debug.WriteLine($"Required time for three numbers: {sw.Elapsed}");
            return gcd2;
        }

        #endregion

            #region Private Methods

        private static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        #endregion
    }
}
