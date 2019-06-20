using System;

namespace Painters.Core
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan TimeBySqMeters { get; }
        double PriceByHour { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimatePrice(double sqMeters);
    }
}