using System;
using Xunit;

namespace FuelCalculator.Tests
{
    public class FuelCalculatorFacts
    {
        [Fact]
        public void RequiresAPositiveMassInput()
        {
            const int mass = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new FuelCalculator().CalculateForMass(mass));
        }

        [Fact]
        public void RequiredFuelForZeroMassIsZero()
        {
            const int mass = 0;

            Assert.Equal(0, new FuelCalculator().CalculateForMass(mass));
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void RequiredFuelForSampleMassesIsCalculatedCorrectly(int mass, int requiredFuel)
        {
            Assert.Equal(requiredFuel, new FuelCalculator().CalculateForMass(mass));
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(654, 966)]
        [InlineData(33583, 50346)]
        public void AddsFuelForFuelMass(int fuelMass, int requiredFuel)
        {
            Assert.Equal(requiredFuel, new FuelCalculator().CalculateForFuelMass(fuelMass));
        }
    }
}
