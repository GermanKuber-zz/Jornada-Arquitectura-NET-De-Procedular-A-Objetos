using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{
    public class PaintersCompany
    {
        public IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            double bestPrice = 0;
            IPainter cheapest = null;
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    double price = painter.EstimatePrice(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                        bestPrice = price;
                    }
                }
            }
            return cheapest;
        }

        public IPainter FindFasterPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan lessTime = default;
            IPainter faster = null;
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    TimeSpan time = painter.EstimateTimeToPaint(sqMeters);
                    if (faster == null || time < lessTime)
                    {
                        faster = painter;
                        lessTime = time;
                    }
                }
            }
            return faster;
        }

        public IPainter WorkTogether(double sqMeters, List<IPainter> painters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    1 /
                    painters
                        .Where(painter => painter.IsAvailable)
                        .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum());

            double cost =
                painters
                    .Where(painter => painter.IsAvailable)
                    .Select(painter =>
                        painter.EstimatePrice(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                    .Sum();

            return new ProportionalPainter(true, TimeSpan.FromHours(time.TotalHours / sqMeters),
                cost / time.TotalHours);
        }
    }
}
