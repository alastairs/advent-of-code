using System;
using System.Collections.Generic;
using System.Linq;

namespace OrbitMap
{
    public class OrbitMap
    {
        private readonly IDictionary<string, string?> _orbits = new Dictionary<string, string?>();

        public static OrbitMap Parse(string mapDescriptor)
        {
            return Parse(mapDescriptor.Trim().Split(Environment.NewLine));
        }

        public static OrbitMap Parse(IEnumerable<string> mapDescriptor)
        {
            var map = new OrbitMap();

            foreach (var orbitDescriptor in mapDescriptor)
            {
                var orbit = orbitDescriptor.Split(")", count: 2);
                map.AddOrbit(orbit.First(), orbit.Last());
            }

            return map;
        }

        public int OrbitsFrom(in string body)
        {
            if (string.IsNullOrWhiteSpace(body) || !_orbits.ContainsKey(body) || _orbits[body] == null)
            {
                return 0;
            }

            return 1 + OrbitsFrom(_orbits[body]!);
        }

        public int TotalOrbits()
        {
            return _orbits.Keys.Sum(o => OrbitsFrom(o));
        }

        private void AddOrbit(string centreOfMass, string body)
        {
            _orbits.TryAdd(centreOfMass, null);
            _orbits.TryAdd(body, null);
            _orbits[body] = centreOfMass;
        }
    }
}