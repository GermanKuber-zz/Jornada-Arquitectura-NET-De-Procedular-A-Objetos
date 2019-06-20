using System;
using System.Collections.Generic;
using System.Linq;
using Painters.Core.Status;

namespace Painters.Core
{
    public class ProportionalOrganizePainters : IOrganizePainters
    {
        public IPainter Organize(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
             TimeSpan.FromHours(
                 1 /
                 painters
                     .Where(painter => painter.Status.Status == PainterStatus.Available)
                     .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                     .Sum());

            double cost =
                painters
                    .Where(painter => painter.Status.Status == PainterStatus.Available)
                    .Select(painter =>
                        painter.EstimatePrice(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                    .Sum();

            return new ProportionalPainter(new AvailablePainterStatus(TimeSpan.FromHours(time.TotalHours / sqMeters), cost / time.TotalHours));
        }
    }
}