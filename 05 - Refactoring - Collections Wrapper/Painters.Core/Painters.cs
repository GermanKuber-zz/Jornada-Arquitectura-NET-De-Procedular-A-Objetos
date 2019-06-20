using System;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{
    //TODO: 01 - Creo una abstracción que represente el grupo de painters
    public class Painters
    {
        public IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            if (painters == null) throw new ArgumentNullException(nameof(painters));

            this.ContainedPainters = painters.ToList();
        }

        public Painters GetAvailable() =>
            new Painters(this.ContainedPainters.Where(painter => painter.Status == PainterStatus.Available));

        public IPainter GetCheapestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimatePrice(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
    }
}