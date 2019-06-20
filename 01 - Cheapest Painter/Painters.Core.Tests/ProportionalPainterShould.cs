using System;
using FluentAssertions;
using Xunit;

namespace Painters.Core.Tests
{
    public class ProportionalPainterShould
    {
        private ProportionalPainter _sut;

        [Fact]
        public void Return_Price()
        {
            _sut = new ProportionalPainter(true, new TimeSpan(0, 0, 30, 0), 10);
            _sut.EstimatePrice(10).Should().Be(50);
        }
    }
}