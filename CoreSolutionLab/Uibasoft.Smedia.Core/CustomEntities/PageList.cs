using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uibasoft.Smedia.Core.CustomEntities
{
    public class PageList<TElement> : List<TElement>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public int? NextPageIndex => HasNextPage ? CurrentPage + 1 : (int?) null;
        public int? PreviousPageIndex => HasPreviousPage ? CurrentPage -1 : (int?) null;
        public PageList(List<TElement> items, int count, int pageIndex, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageIndex;
            TotalPages = (int) Math.Ceiling( count / (double) pageSize);
            AddRange(items);
        }

        public static PageList<TElement> Create(IEnumerable<TElement> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<TElement>(items,count,pageIndex, pageSize);
        }
    }
}
