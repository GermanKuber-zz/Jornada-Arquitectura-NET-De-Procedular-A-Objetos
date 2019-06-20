using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{
    public class PaintersCompany
    {
        private readonly IEnumerable<IPainter> _painters;

        public PaintersCompany(IEnumerable<IPainter> painters)
        {
            _painters = painters;
        }
        public IPainter FindCheapestPainter(double sqMeters)
        {
            double bestPrice = 0;
            IPainter cheapest = null;
            foreach (var painter in _painters)
            {
                if (painter.Available)
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
    }
}
