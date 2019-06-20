using System;
using System.Collections;
using System.Collections.Generic;

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
    }
}
