using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCPage
{
    public class PaginatedList<T> : List<T>
    {
       
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        
        public PaginatedList(IEnumerable<T> item, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(item);
        }
        public bool HasPrevious
        {
            get { return PageIndex > 1; }
        }
        public bool HasNext
        {
            get { return PageIndex < TotalPages; }
        }
        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count();
            var item =  source.Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();
            return new PaginatedList<T>(item, count, pageIndex, pageSize);
        }
    }
}