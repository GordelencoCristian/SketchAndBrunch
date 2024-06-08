namespace SharedData.Models.Pagination
{
    public abstract class BasePagedList<T> : List<T>
    {
        public BasePagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PagedSummary = new PaginatedHeaderParameter()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };

            this.AddRange(items);
        }

        public PaginatedHeaderParameter PagedSummary { get; set; }

        public bool HasPrevious => this.PagedSummary.CurrentPage > 1;

        public bool HasNext => this.PagedSummary.CurrentPage < this.PagedSummary.TotalPages;
    }
}
