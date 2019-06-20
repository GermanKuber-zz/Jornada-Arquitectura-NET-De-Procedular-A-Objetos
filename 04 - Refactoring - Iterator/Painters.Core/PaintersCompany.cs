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

        //TODO: 02 - Remplazo el foreach con el método de extensión
        public IPainter FindCheapestPainter(double sqMeters) =>
            _painters
                .Where(painter => painter.Status == PainterStatus.Available)
                .WithMinimum(painter => painter.EstimatePrice(sqMeters));

        public IPainter FindFasterPainter(double sqMeters)
        {
            TimeSpan lessTime = default;
            IPainter faster = null;
            foreach (var painter in _painters)
            {
                if (painter.Status == PainterStatus.Available)
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

        public IPainter WorkTogether(double sqMeters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    1 /
                    _painters
                        .Where(painter => painter.Status == PainterStatus.Available)
                        .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum());

            double cost =
                _painters
                    .Where(painter => painter.Status == PainterStatus.Available)
                    .Select(painter =>
                        painter.EstimatePrice(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                    .Sum();

            return new ProportionalPainter(PainterStatus.Available, TimeSpan.FromHours(time.TotalHours / sqMeters),
                cost / time.TotalHours);
        }
    }
}
