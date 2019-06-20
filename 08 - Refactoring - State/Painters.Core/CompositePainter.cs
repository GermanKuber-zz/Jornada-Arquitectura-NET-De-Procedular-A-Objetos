using System;
using System.Collections.Generic;
using System.Linq;
using Painters.Core.Status;

namespace Painters.Core
{
    public class CompositePainter : IPainter
    {
        private IEnumerable<IPainter> Painters { get; }

        public IPainterStatus Status
        {
            get
            {
                if (Painters.Any(painter => painter.Status.Status == PainterStatus.Available))
                    return new AvailablePainterStatus(TimeBySqMeters, PriceByHour);
                else
                    return new UnavailablePainterStatus(TimeBySqMeters, PriceByHour);

            }
        }
        public TimeSpan TimeBySqMeters =>
            new TimeSpan(Convert.ToInt64(Painters.Average(painter => painter.Status.TimeBySqMeters.Ticks)));

        public double PriceByHour =>
            Painters.Average(painter => painter.Status.PriceByHour);


        private readonly IOrganizePainters _organizePainters;

        public CompositePainter(Painters painters, IOrganizePainters organizePainters)
        {
            this.Painters = painters.ContainedPainters.ToList();
            _organizePainters = organizePainters;
        }
        private IPainter Reduce(double sqMeters) =>
            _organizePainters.Organize(sqMeters, Painters);



        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters).EstimateTimeToPaint(sqMeters);


        public double EstimatePrice(double sqMeters) =>
            this.Reduce(sqMeters).EstimatePrice(sqMeters);
    }
}