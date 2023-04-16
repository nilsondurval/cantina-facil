using CantinaFacil.Shared.Kernel.Data;
using System.Collections.Generic;

namespace CantinaFacil.Shared.Kernel.Domain
{
    public class QueryFilter<T>
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public IEnumerable<SortMeta> SortMeta { get; private set; }
        public T Filter { get; private set; }

        public QueryFilter(int page, int pageSize, IEnumerable<SortMeta> sortMeta, T filter)
        {
            Page = page;
            PageSize = pageSize;
            SortMeta = sortMeta;
            Filter = filter;
        }
    }
}
