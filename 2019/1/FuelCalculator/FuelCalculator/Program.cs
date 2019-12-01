using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuelCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var path = args[0];
            var cancellation = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) => cancellation.Cancel();

            var modules = await File.ReadAllLinesAsync(path, cancellation.Token);
            var fuelCalculator = new FuelCalculator();

            var totalMass = modules.AsParallel()
                .Select(int.Parse)
                .Aggregate(
                    0,
                    (t, moduleMass) =>
                        t + fuelCalculator.CalculateForMass(moduleMass));

            Console.WriteLine($"Total required fuel mass is: {totalMass}");
        }
    }

    public class FuelCalculator
    {
        public int CalculateForFuelMass(int mass)
        {
            if (mass < 5)
            {
                return mass;
            }

            return mass + CalculateForFuelMass(CalculateForMass(mass));
        }

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
