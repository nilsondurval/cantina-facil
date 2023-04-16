using CantinaFacil.Shared.Kernel.Domain;
using System.Linq;

namespace CantinaFacil.Shared.Kernel.Data.Pagination
{
    public static class PaginationExtensions
    {
        public static PaginationResult<T> GetPagination<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {

            var totalRecords = query.Count();
            int skip = (page - 1) * pageSize;
            var result = query
                .Skip(skip)
                .Take(pageSize);

            return new PaginationResult<T>(page, pageSize, totalRecords, result);
        }
    }
}
