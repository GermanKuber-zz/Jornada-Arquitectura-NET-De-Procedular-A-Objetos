using System;

namespace Painters.Core
{
    public class ProportionalPainter : IPainter
    {
        private readonly TimeSpan _timeBySqMeters;
        private readonly double _priceByHour;
        public bool Available { get; private set; }

        public ProportionalPainter(bool available, TimeSpan timeBySqMeters, double priceByHour)
        {

            Available = available;
            _timeBySqMeters = timeBySqMeters;
            _priceByHour = priceByHour;
        }
        
        private TimeSpan EstimateTimeToPaint(double sqMeters) =>
            _timeBySqMeters.Multiply(sqMeters);

        public double EstimatePrice(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * _priceByHour;
    }
}