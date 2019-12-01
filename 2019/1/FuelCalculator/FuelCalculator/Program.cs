using System;
using System.Collections;
using System.Collections.Generic;
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

            int totalMass;
            var fuelCalculator = new FuelCalculator();

            if (int.TryParse(args[0], out var moduleMass))
            {
                totalMass = fuelCalculator.AggregateFuelForModules(new[] { moduleMass });
            }
            else
            {
                var modules = await File.ReadAllLinesAsync(path, cancellation.Token);
                totalMass = fuelCalculator
                    .AggregateFuelForModules(
                        modules.AsParallel().Select(int.Parse));
            }

            Console.WriteLine($"Total required fuel mass is: {totalMass}");
        }
    }

    public class FuelCalculator
    {
        public int AggregateFuelForModules(IEnumerable<int> moduleMasses)
        {
            return CalculateForMass(
                moduleMasses.AsParallel()
                    .Aggregate(
                        0,
                        (t, moduleMass) =>
                        {
                            var fuelMass = CalculateForMass(moduleMass);
                            return t + fuelMass + CalculateForFuelMass(fuelMass);
                        }));
        }

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
