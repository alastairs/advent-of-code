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

            var mapDescriptor = File.ReadAllText(args[0]);
            var map = OrbitMap.Parse(mapDescriptor);
            Console.WriteLine("Previously-calculated total of 3328 was too low.");
            Console.WriteLine($"Total orbits in the map is: {map.TotalOrbits()}");
        }
    }
}
