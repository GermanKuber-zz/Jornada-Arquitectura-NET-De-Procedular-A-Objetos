using System;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;
namespace Painters.Core.Tests
{
    public class PaintersCompanyShould
    {
        private readonly PaintersCompany _sut;
        private readonly List<IPainter> _listOfPainters;

        public PaintersCompanyShould()
        {
            _sut = new PaintersCompany();
            _listOfPainters = new List<IPainter>
            {
                new Painter(true, new TimeSpan(0,1,0,0),10 ),
                new Painter(true, new TimeSpan(0,0,50,0),15 ),
                new Painter(true, new TimeSpan(0,0,40,0),19 )
            };

        }
        [Fact]
        public void Return_Cheapest_Painter()
        {
            var cheapest = new Painter(true, new TimeSpan(0, 0, 30, 0, 0), 11);
            _listOfPainters.Add(cheapest);
            _sut.FindCheapestPainter(30, _listOfPainters).Should().Be(cheapest);
        }

        [Fact]
        public void Return_Faster_Painter()
        {
            var faster = new Painter(true, new TimeSpan(0, 0, 39, 0, 0), 11);
            _listOfPainters.Add(faster);
            _sut.FindFasterPainter(30, _listOfPainters).Should().Be(faster);
        }
    }
}
