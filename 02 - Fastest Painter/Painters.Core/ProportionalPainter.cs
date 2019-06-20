using System;

namespace Painters.Core
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimeBySqMeters { get; }
        public double PriceByHour { get; }
        public PainterStatus Status { get; private set; }



        public ProportionalPainter(PainterStatus status, TimeSpan timeBySqMeters, double priceByHour)
        {
            TimeBySqMeters = timeBySqMeters;
            PriceByHour = priceByHour;
            Status = status;
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            switch (Status)
            {
                case PainterStatus.Unavailable:
                    return TimeSpan.Zero;
                default:
                    return TimeBySqMeters.Multiply(sqMeters);
            }
        }

        public double EstimatePrice(double sqMeters)
        {
            switch (Status)
            {
                case PainterStatus.Available:
                    return EstimateTimeToPaint(sqMeters).TotalHours * PriceByHour;
                default:
                    return 0;
            }
        }
    }
}