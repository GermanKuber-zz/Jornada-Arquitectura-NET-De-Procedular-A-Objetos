using System;
using System.Collections.Generic;
using System.Linq;

namespace Painters.Core
{
    public static class EnumerableExtensions
    {
        //TODO: 01 -  Creo un método de extensión con la logica comun, para obtener el primero de un criterio
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            sequence.OrderBy(criterion)
                .FirstOrDefault();
    }
}