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
            throw new ArgumentOutOfRangeException(nameof(mass));
        }
    }
}
