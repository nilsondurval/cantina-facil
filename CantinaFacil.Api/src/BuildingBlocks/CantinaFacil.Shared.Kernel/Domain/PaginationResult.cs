using System;
using System.Collections.Generic;
using System.Linq;

namespace CantinaFacil.Shared.Kernel.Domain
{
    public class PaginationResult<T>
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int TotalRecords { get; private set; }
        public IQueryable<T>? Query { get; set; }
        public IEnumerable<T>? Result { get; private set; }

        public PaginationResult()
        {

        }

        public PaginationResult(int page, int pageSize, int totalRecords, IQueryable<T> query)
        {
            Page = page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Query = query;
        }

        public PaginationResult(int page, int pageSize, int totalRecords, IQueryable<T> query, IEnumerable<T> result)
        {
            Page = page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Query = query;
            Result = result;
        }       
    }
}
