using System;

namespace Painters.Core
{
    public class ProportionalPainter : IPainter
    {
        private readonly double _priceByHourInHolidays;
        public TimeSpan TimeBySqMeters { get; }
        public double PriceByHour { get; }
        public PainterStatus Status { get; private set; }



        public ProportionalPainter(PainterStatus status, 
                                   TimeSpan timeBySqMeters, 
                                   double priceByHour, 
                                   double? priceByHourInHolidays = null)
        {
            if (status == PainterStatus.InHolidays && priceByHourInHolidays == null)
                throw new ArgumentNullException(nameof(priceByHourInHolidays));
            _priceByHourInHolidays = priceByHourInHolidays ?? 0;
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
                case PainterStatus.InHolidays:
                    return EstimateTimeToPaint(sqMeters).TotalHours * _priceByHourInHolidays;
                default:
                    return 0;
            }
        }
    }
}