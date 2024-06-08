using System.Linq.Expressions;

namespace SharedData.Models.Pagination
{
    public class PaginatedList<T> : BasePagedList<T>
    {
        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
            : base(items, count, pageNumber, pageSize)
        {

        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }

        public static PaginatedList<T> Create(List<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }

    public class PaginatedList<TSource, TDestination> : BasePagedList<TDestination>
    {
        public PaginatedList(List<TDestination> items, int count, int pageNumber, int pageSize)
            : base(items, count, pageNumber, pageSize)
        {

        }

        public static PaginatedList<TSource, TDestination> Create(IQueryable<TSource> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            var expression = typeof(TDestination).GetProperty("Projection").GetValue(null) as Expression<Func<TSource, TDestination>>;

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(expression).ToList();

            return new PaginatedList<TSource, TDestination>(items, count, pageNumber, pageSize);
        }
    }
}
