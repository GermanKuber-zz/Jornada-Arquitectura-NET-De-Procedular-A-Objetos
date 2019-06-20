using System.Collections.Generic;

namespace Painters.Core
{
    public interface IOrganizePainters
    {
        IPainter Organize(double sqMeters, IEnumerable<IPainter> painters);
    }
}