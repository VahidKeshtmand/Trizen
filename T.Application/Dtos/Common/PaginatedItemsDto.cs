namespace T.Application.Dtos.Common;

public class PaginatedItemsDto<T> where T : class
{
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public long Count { get; private set; }
    public List<T> Data { get; private set; } = new();
    public int TotalPages { get; set; }
    public Pager Pager { get; private set; }

    public PaginatedItemsDto(int pageIndex, int pageSize, long count, List<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
        TotalPages = (int)Math.Ceiling((decimal)count / (decimal)pageSize);
        Pager = new Pager(count, pageIndex, pageSize);
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < TotalPages);
        }
    }
}

public class Pager
{
    public Pager(long totalItems, int currentPage = 1, int pageSize = 10, int maxPages = 5)
    {
        // calculate total pages
        var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

        // ensure current page isn't out of range
        if (currentPage < 1)
        {
            currentPage = 1;
        }
        else if (currentPage > totalPages)
        {
            currentPage = totalPages;
        }

        int startPage, endPage;
        if (totalPages <= maxPages)
        {
            // total pages less than max so show all pages
            startPage = 1;
            endPage = totalPages;
        }
        else
        {
            // total pages more than max so calculate start and end pages
            var maxPagesBeforeCurrentPage = (int)Math.Floor((decimal)maxPages / (decimal)2);
            var maxPagesAfterCurrentPage = (int)Math.Ceiling((decimal)maxPages / (decimal)2) - 1;
            if (currentPage <= maxPagesBeforeCurrentPage)
            {
                // current page near the start
                startPage = 1;
                endPage = maxPages;
            }
            else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
            {
                // current page near the end
                startPage = totalPages - maxPages + 1;
                endPage = totalPages;
            }
            else
            {
                // current page somewhere in the middle
                startPage = currentPage - maxPagesBeforeCurrentPage;
                endPage = currentPage + maxPagesAfterCurrentPage;
            }
        }
        // calculate start and end item indexes
        var startIndex = (currentPage - 1) * pageSize;
        var endIndex = Math.Min(startIndex + pageSize - 1, totalItems - 1);

        // create an array of pages that can be looped over
        var pages = Enumerable.Range(startPage, (endPage + 1) - startPage);


        TotalPages = totalPages;
        Pages = pages;
    }
    public IEnumerable<int> Pages { get; private set; }
    public int TotalPages { get; private set; }
}
