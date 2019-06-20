using System;
using System.Collections.Generic;
using System.Linq;
using Painters.Core.Status;

namespace Painters.Core
{

    public class Painters
    {
        public IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            if (painters == null) throw new ArgumentNullException(nameof(painters));

            this.ContainedPainters = painters.ToList();
        }

        public Painters GetAvailable() =>
            new Painters(this.ContainedPainters.Where(painter => painter.Status.Status == PainterStatus.Available));

        public IPainter GetCheapestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimatePrice(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
    }
}