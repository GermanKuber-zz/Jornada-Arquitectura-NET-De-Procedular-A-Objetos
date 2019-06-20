using System;

namespace Painters.Core
{
    public interface IPainter
    {
        PainterStatus Status { get; }
        TimeSpan TimeBySqMeters { get; }
        double PriceByHour { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimatePrice(double sqMeters);
    }
}