using System;

namespace Painters.Core
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimatePrice(double sqMeters);
    }
}