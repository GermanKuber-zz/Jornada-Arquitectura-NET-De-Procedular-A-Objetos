using System;
using System.Collections;
using System.Linq;

namespace Painters.Core
{
    public class PaintersCompany
    {
        private readonly Painters _painters;

        public PaintersCompany(Painters painters)
        {
            _painters = painters;
        }

        public IPainter FindCheapestPainter(double sqMeters) =>
            _painters
                .GetAvailable()
                .GetCheapestOne(sqMeters);

        public IPainter FindFasterPainter(double sqMeters) =>
            _painters
                .GetAvailable()
                .GetFastestOne(sqMeters);

        public IPainter WorkTogether(double sqMeters)
        {
            TimeSpan time =
                TimeSpan.FromHours(
                    1 /
                    _painters
                        .ContainedPainters
                        .Where(painter => painter.Status == PainterStatus.Available)
                        .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum());

            double cost =
                _painters
                    .ContainedPainters
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
