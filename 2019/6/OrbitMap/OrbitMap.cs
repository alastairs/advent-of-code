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

        public int TransfersTo(in string from = "YOU", in string to = "SAN")
        {
            var fromParentList = ParentsOf(from);
            var toParentList = ParentsOf(to);

            var commonParents = fromParentList.Reverse().Intersect(toParentList.Reverse()).ToList();

            return fromParentList.ToList().IndexOf(commonParents.Last()) + toParentList.ToList().IndexOf(commonParents.Last()) - 2;
        }

        private IEnumerable<string> ParentsOf(in string body)
        {
            var parents = new List<string>();

            for(var current = body; _orbits[current] != null; current = _orbits[current]!)
            {
                parents.Add(current);
            }

            return parents;
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