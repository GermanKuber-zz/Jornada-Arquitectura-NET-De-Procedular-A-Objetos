using System;

namespace Painters.Core.Status
{
    public class AvailablePainterStatus : IPainterStatus
    {
        public TimeSpan TimeBySqMeters { get; }
        public double PriceByHour { get; }

        public PainterStatus Status => PainterStatus.Available;

        public AvailablePainterStatus(TimeSpan timeBySqMeters, double priceByHour)
        {
            TimeBySqMeters = timeBySqMeters;
            PriceByHour = priceByHour;
        }
        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeBySqMeters.Multiply(sqMeters);
        public double EstimatePrice(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * PriceByHour;
    }
}