using System;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{
    public class CompositePainter : IPainter
    {
        private IEnumerable<IPainter> Painters { get; }

        public PainterStatus Status
        {
            get
            {
                if (Painters.Any(painter => painter.Status == PainterStatus.Available))
                    return PainterStatus.Available;
                else
                    return PainterStatus.Unavailable;
            }
        }
        public TimeSpan TimeBySqMeters => new TimeSpan(Convert.ToInt64(Painters.Average(painter => painter.TimeBySqMeters.Ticks)));

        public double PriceByHour => Painters.Average(painter => painter.PriceByHour);


        public CompositePainter(Painters painters)
        {
            this.Painters = painters.ContainedPainters.ToList();

        }
        private IPainter Reduce(double sqMeters)
        {
            TimeSpan time =
               TimeSpan.FromHours(
                   1 /
                   Painters
                       .Where(painter => painter.Status == PainterStatus.Available)
                       .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                       .Sum());

            double cost =
                Painters
                    .Where(painter => painter.Status == PainterStatus.Available)
                    .Select(painter =>
                        painter.EstimatePrice(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                    .Sum();

            return new ProportionalPainter(PainterStatus.Available, TimeSpan.FromHours(time.TotalHours / sqMeters),
                cost / time.TotalHours);
        }



        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters).EstimateTimeToPaint(sqMeters);



        public double EstimatePrice(double sqMeters) =>
            this.Reduce(sqMeters).EstimatePrice(sqMeters);
    }
}