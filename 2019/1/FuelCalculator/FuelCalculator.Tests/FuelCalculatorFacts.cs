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
    }
}
