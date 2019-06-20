using System;

namespace Painters.Core.Status
{
    public class InHolidaysPainterStatus : IPainterStatus
    {
        public PainterStatus Status => PainterStatus.InHolidays;

        public TimeSpan TimeBySqMeters { get; }
        public double PriceByHour { get; }
        private double _priceByHourInHolidays;

        public InHolidaysPainterStatus(TimeSpan timeBySqMeters, double priceByHourInHolidays)
        {
            TimeBySqMeters = timeBySqMeters;
            _priceByHourInHolidays = priceByHourInHolidays;
        }
        public TimeSpan EstimateTimeToPaint(double sqMeters) => TimeBySqMeters.Multiply(sqMeters);
        public double EstimatePrice(double sqMeters) => EstimateTimeToPaint(sqMeters).TotalHours * _priceByHourInHolidays;
    }
}