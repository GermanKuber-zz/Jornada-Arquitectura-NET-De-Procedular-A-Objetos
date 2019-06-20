using System;

namespace Painters.Core
{
    public class Painter : IPainter
    {
        private readonly TimeSpan _timeBySqMeters;
        private readonly double _priceByHour;
        public bool IsAvailable { get; private set; }


        public Painter(bool isAvailable, TimeSpan timeBySqMeters, double priceByHour)
        {
            _timeBySqMeters = timeBySqMeters;
            _priceByHour = priceByHour;
            IsAvailable = isAvailable;
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            _timeBySqMeters.Multiply(sqMeters);

        public double EstimatePrice(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * _priceByHour;
    }
}