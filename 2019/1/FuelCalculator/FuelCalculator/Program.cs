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
        public int CalculateForMass(int mass)
        {
            if (mass < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(mass));
            }

            int CalculateRequiredFuelMass()
            {
                return (int) Math.Floor((double) mass / 3) - 2;
            }

            return Math.Max(0, CalculateRequiredFuelMass());
        }
    }
}
