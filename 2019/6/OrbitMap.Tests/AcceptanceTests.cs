using Xunit;

namespace OrbitMap.Tests
{
    public class AcceptanceTests
    {
        [Fact]
        public void Sample_map_is_parsed_correctly()
        {
            const string sampleMap = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
";

            var map = OrbitMap.Parse(sampleMap);

            Assert.Equal(3, map.OrbitsFrom("D"));
            Assert.Equal(7, map.OrbitsFrom("L"));
            Assert.Equal(0, map.OrbitsFrom("COM"));
            Assert.Equal(42, map.TotalOrbits());
        }

        [Fact]
        public void Direct_orbits_are_recorded()
        {
            var map = OrbitMap.Parse(@"COM)A");
            Assert.Equal(1, map.OrbitsFrom("A"));
        }

        [Fact]
        public void Indirect_orbits_are_recorded()
        {
            var map = OrbitMap.Parse(@"COM)A
A)B");
            Assert.Equal(2, map.OrbitsFrom("B"));
        }
    }
}