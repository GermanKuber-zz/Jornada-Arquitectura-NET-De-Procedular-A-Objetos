using System;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
namespace Painters.Core.Tests
{
    public class PaintersCompanyShould
    {
        private  PaintersCompany _sut;

        private readonly ProportionalPainter _cheapest =
            new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 0, 30, 0, 0), 11);
        public PaintersCompanyShould()
        {
            _sut = new PaintersCompany(new List<IPainter>
            {
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 1, 0, 0), 10),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 0, 50, 0), 15),
                new ProportionalPainter(PainterStatus.Available, new TimeSpan(0, 0, 40, 0), 19),
                _cheapest
            });
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
    }
}
