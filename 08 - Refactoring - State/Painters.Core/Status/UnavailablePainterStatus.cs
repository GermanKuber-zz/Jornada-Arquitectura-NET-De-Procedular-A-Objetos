using System;

namespace Painters.Core.Status
{
    public class UnavailablePainterStatus : IPainterStatus
    {
        public PainterStatus Status => PainterStatus.Unavailable;

        public TimeSpan TimeBySqMeters { get; }
        public double PriceByHour { get; }

        public UnavailablePainterStatus(TimeSpan timeBySqMeters, double priceByHour)
        {
            TimeBySqMeters = timeBySqMeters;
            PriceByHour = priceByHour;
        }
        public TimeSpan EstimateTimeToPaint(double sqMeters) => TimeSpan.Zero;
        public double EstimatePrice(double sqMeters) => 0;
    }
}