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

        public IPainter WorkTogether(double sqMeters) =>
            new CompositePainter(_painters);
    }
}
