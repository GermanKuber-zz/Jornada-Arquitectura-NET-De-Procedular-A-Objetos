using System;

namespace Painters.Core.Status
{
    public interface IPainterStatus
    {
        PainterStatus Status { get; }
        TimeSpan TimeBySqMeters { get; }
        double PriceByHour { get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimatePrice(double sqMeters);
    }
}