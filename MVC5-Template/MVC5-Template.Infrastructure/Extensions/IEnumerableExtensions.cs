using System.Collections.Generic;
using System.Linq;

using MVC5_Template.Services.Mappings;

namespace MVC5_Template.Infrastructure.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> collection)
        {
            return collection.Select(e => MappingService.MappingProvider.Map<T2>(e));
        }
    }
}
