using System;
using System.Collections.Generic;
using System.Linq;

namespace OrbitMap
{
    public class OrbitMap
    {
        private readonly IDictionary<string, List<string>> _orbits = new Dictionary<string, List<string>>();

        public static OrbitMap Parse(string mapDescriptor)
        {
            var map = new OrbitMap();

            foreach (var orbitDescriptor in mapDescriptor.Trim().Split(Environment.NewLine))
            {
                var orbit = orbitDescriptor.Split(")");
                map.AddOrbit(orbit.First(), orbit.Last());
            }

            return map;
        }

        public int OrbitsFrom(in string body)
        {
            return !_orbits.ContainsKey(body) ? 0 : _orbits[body].Count;
        }

        private void AddOrbit(string centreOfMass, string body)
        {
            if (!_orbits.ContainsKey(body))
            {
                _orbits[body] = new List<string>();
            }

            _orbits[body].Add(centreOfMass);

            if (!_orbits.ContainsKey(centreOfMass))
            {
                return;
            }

            foreach (var orbit in _orbits[centreOfMass])
            {
                _orbits[body].Add(orbit);
            }
        }

        public int TotalOrbits()
        {
            return _orbits.Keys.Sum(o => OrbitsFrom(o));
        }
    }
}