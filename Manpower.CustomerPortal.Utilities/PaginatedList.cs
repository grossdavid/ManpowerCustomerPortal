using System.Collections.Generic;
using System.Linq;

namespace Manpower.CustomerPortal.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList()
        {
            
        }

        public PaginatedList(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public int TotalItems { get; set; }

        public static PaginatedList<T> ToPaginatedList(IEnumerable<T> rawCollection, int page, int pageSize)
        {
            var totalItems = rawCollection.Count();
            return new PaginatedList<T>(rawCollection.Skip((page - 1) * pageSize).Take(pageSize))
                       {
                           TotalItems = totalItems
                       };
        }
    }
}
