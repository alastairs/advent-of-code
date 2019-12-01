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
        public void RequiredFuelForSampleMassesIsCalculatedCorrectly(int mass, int requiredFuel)
        {
            Assert.Equal(requiredFuel, new FuelCalculator().CalculateForMass(mass));
        }
    }
}
