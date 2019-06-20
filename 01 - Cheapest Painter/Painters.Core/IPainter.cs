using System;

namespace Painters.Core
{
    public interface IPainter
    {
        bool Available { get; }
        double EstimatePrice(double sqMeters);
    }
}