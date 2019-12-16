using System;
using System.IO;

namespace OrbitMap
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine(@"USAGE: OrbitMap path/to/input.txt");
                return;
            }

            var mapDescriptor = File.ReadAllLines(args[0]);
            var map = OrbitMap.Parse(mapDescriptor);
            Console.WriteLine($"Total orbits in the map is: {map.TotalOrbits()}");
            Console.WriteLine($"Orbital transfers from us to Santa is {map.TransfersTo(from: "YOU", to: "SAN")}");
        }
    }
}
