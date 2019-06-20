using System;
using FluentAssertions;
using Xunit;

namespace Painters.Core.Tests
{
    public class ProportionalPainterShould
    {
        private ProportionalPainter _sut;


        [Fact]
        public void Throw_Exception_If_Painter_Is_In_Holidays_And_Price_In_Holidays_Is_Null()
        {
            Action act = () => new ProportionalPainter(PainterStatus.InHolidays, TimeSpan.MinValue, 2);
            act.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void Return_Price_In_Holidays()
        {
            _sut= new ProportionalPainter(PainterStatus.InHolidays, new TimeSpan(0,0,30,0), 10, 20);
            _sut.EstimatePrice(10).Should().Be(100);
        }
        [Fact]
        public void Return_Time_Zero_Unavailable()
        {
            _sut = new ProportionalPainter(PainterStatus.Unavailable, new TimeSpan(0, 0, 30, 0), 10, 20);
            _sut.EstimateTimeToPaint(300).Should().Be(TimeSpan.Zero);
        }
    }
}