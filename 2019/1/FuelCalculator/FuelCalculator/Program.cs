using System;

namespace FuelCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class FuelCalculator
    {
        public int CalculateForMass(in int mass)
        {
            if (mass < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(mass));
            }

            if (mass == 0)
            {
                return 0;
            }

            return 2;
        }
    }
}
