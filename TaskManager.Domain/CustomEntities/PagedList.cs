namespace TaskManager.Domain.CustomEntities
{
    
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; } 
        public int CurrentPage { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public bool HasNextPage => CurrentPage < TotalPages;
        public bool HasPreviousPage => CurrentPage > 1;
        public int? NextPage => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPage => HasPreviousPage ? CurrentPage - 1 : (int?)null; 
        public static PagedList<T> CreateList(IEnumerable<T> data, int pageNumber, int pageSize)
        {
            var count = data.Count();
            var list = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(list,count, pageNumber, pageSize);
        }
        public PagedList(List<T> list, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages =(int) Math.Ceiling((double)list.Count / pageSize);
            AddRange(list);
        }
         
    }
}
