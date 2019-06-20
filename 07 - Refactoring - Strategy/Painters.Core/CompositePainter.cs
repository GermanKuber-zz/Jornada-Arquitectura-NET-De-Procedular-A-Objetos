using System;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{

    public interface IOrganizePainters
    {
        IPainter Organize(double sqMeters, IEnumerable<IPainter> painters);
    }

    public class ProportionalOrganizePainters : IOrganizePainters
    {
        public IPainter Organize(double sqMeters, IEnumerable<IPainter> painters)
        {
            TimeSpan time =
             TimeSpan.FromHours(
                 1 /
                 painters
                     .Where(painter => painter.Status == PainterStatus.Available)
                     .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                     .Sum());

            double cost =
                painters
                    .Where(painter => painter.Status == PainterStatus.Available)
                    .Select(painter =>
                        painter.EstimatePrice(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                    .Sum();

            return new ProportionalPainter(PainterStatus.Available, TimeSpan.FromHours(time.TotalHours / sqMeters),
                cost / time.TotalHours);
        }
    }
    public class CompositePainter : IPainter
    {
        private IEnumerable<IPainter> Painters { get; }

        public PainterStatus Status
        {
            get
            {
                if (Painters.Any(painter => painter.Status == PainterStatus.Available))
                    return PainterStatus.Available;
                else
                    return PainterStatus.Unavailable;
            }
        }
        public TimeSpan TimeBySqMeters =>
            new TimeSpan(Convert.ToInt64(Painters.Average(painter => painter.TimeBySqMeters.Ticks)));

        public double PriceByHour =>
            Painters.Average(painter => painter.PriceByHour);

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