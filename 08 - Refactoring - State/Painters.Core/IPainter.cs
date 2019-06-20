using System;
using Painters.Core.Status;

namespace Painters.Core
{
    public interface IPainter
    {
        IPainterStatus Status { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimatePrice(double sqMeters);
    }
}