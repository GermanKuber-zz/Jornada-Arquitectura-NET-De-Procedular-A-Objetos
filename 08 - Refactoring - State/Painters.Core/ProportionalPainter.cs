using System;
using Painters.Core.Status;

namespace Painters.Core
{


    public class ProportionalPainter : IPainter
    {
        public IPainterStatus Status { get; private set; }


        public ProportionalPainter(IPainterStatus status)
        {
            Status = status;
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Status.EstimateTimeToPaint(sqMeters);

        public double EstimatePrice(double sqMeters) =>
            Status.EstimatePrice(sqMeters);
    }
}