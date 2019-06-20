using System;
using FluentAssertions;
using Painters.Core.Status;
using Xunit;

namespace Painters.Core.Tests
{
    public class ProportionalPainterShould
    {
        private ProportionalPainter _sut;


        [Fact]
        public void Return_Price_In_Holidays()
        {
            _sut = new ProportionalPainter(new InHolidaysPainterStatus(new TimeSpan(0, 0, 30, 0),  20));
            _sut.EstimatePrice(10).Should().Be(100);
        }

        [Fact]
        public void Return_Price_Zero_Unavailable()
        {
            _sut = new ProportionalPainter(new UnavailablePainterStatus( new TimeSpan(0, 0, 30, 0), 10));
            _sut.EstimatePrice(10).Should().Be(0);
        }
        [Fact]
        public void Return_Time_Zero_Unavailable()
        {
            _sut = new ProportionalPainter(new UnavailablePainterStatus(new TimeSpan(0, 0, 30, 0), 10));
            _sut.EstimateTimeToPaint(300).Should().Be(TimeSpan.Zero);
        }
    }
}