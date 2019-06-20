using System;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
namespace Painters.Core.Tests
{
    public class PaintersCompanyShould
    {
        private PaintersCompany _sut;

        private readonly ProportionalPainter _cheapest =
            new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 0, 30, 0, 0), 11);
        public PaintersCompanyShould()
        {
            _sut = new PaintersCompany(new Painters(new List<IPainter>
            {
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 1, 0, 0), 10),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 0, 50, 0), 15),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 0, 40, 0), 19),
                _cheapest
            }));
        }
        [Fact]
        public void Return_Cheapest_Painter()
        {
            _sut.FindCheapestPainter(30).Should().Be(_cheapest);
        }

        [Fact]
        public void Return_Faster_Painter()
        {
            _sut.FindFasterPainter(30).Should().Be(_cheapest);
        }

        [Fact]
        public void Return_New_Painter_With_Proportional_Price_And_Time()
        {
            _sut = new PaintersCompany(new Painters(new List<IPainter>
            {
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0,0,20,0),10 ),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0,0,30,0),20 ),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0,0,40,0),30 )
            }));
            var painter = _sut.WorkTogether(30);
        }

        [Fact]
        public void Throw_Exception_If_Painter_Is_In_Holidays_And_Price_In_Holidays_Is_Null()
        {
            _sut = new PaintersCompany(new Painters(new List<IPainter>
            {
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0,0,20,0),10 ),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0,0,30,0),20 ),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0,0,40,0),30 )
            }));
            var painter = _sut.WorkTogether(30);
        }
    }
}
