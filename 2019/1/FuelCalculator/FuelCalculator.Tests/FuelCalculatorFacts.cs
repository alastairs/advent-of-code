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
    }
}
