using System;

namespace Painters.Core
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimeBySqMeters { get; }
        public double PriceByHour { get; }
        public bool IsAvailable { get; private set; }
      


        public ProportionalPainter(bool isAvailable, TimeSpan timeBySqMeters, double priceByHour)
        {
            TimeBySqMeters = timeBySqMeters;
            PriceByHour = priceByHour;
            IsAvailable = isAvailable;
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeBySqMeters.Multiply(sqMeters);

        public double EstimatePrice(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * PriceByHour;
    }
}