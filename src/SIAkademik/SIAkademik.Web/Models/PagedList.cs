using System.Collections;

namespace SIAkademik.Web.Models;

public class PagedList<T> : IEnumerable<T>
{
    private readonly List<T> _list;

    public int PageSize { get; init; }
    public int PageIndex { get; init; }
    public int PageCount { get; init; }

    public bool HasPrevious => PageIndex > 0;
    public int PreviousPageIndex => HasPrevious ? PageIndex - 1 : PageCount - 1;
    public bool HasNext => PageIndex < PageCount - 1;
    public int NextPageIndex => HasNext ? PageIndex + 1 : 0;
    public List<int> PageNumbers => [.. Enumerable.Range(0, PageCount)];

    public PagedList()
    {
        _list = [];
        PageSize = 0;
        PageIndex = 0;
    }

    public PagedList(IEnumerable<T> values, int pageSize, int pageIndex)
    {
        if (pageSize < 0) throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize can't be negative");
        if (pageIndex < 0) throw new ArgumentOutOfRangeException(nameof(pageIndex), "pageIndex can't be negatove");
        PageSize = pageSize;

        if (values is not null && values.Any())
        {
            PageCount = values.Count() / pageSize + 1;

            if (pageIndex > PageCount) throw new ArgumentOutOfRangeException(nameof(pageIndex), "pageIndex out of range");
            PageIndex = pageIndex;

            _list = [.. values.Skip(PageIndex * PageSize).Take(PageSize)];
        }
        else
        {
            PageCount = 0;
            PageIndex = 0;
            _list = [];
        }
    }

    public T this[int index] { get => _list[index]; }

    public int Count => _list.Count;

    public bool Contains(T item) => _list.Contains(item);

    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public static class PagedList
{
    public static PagedList<T> ToPagedList<T>(this IEnumerable<T> values, int pageSize, int pageIndex) =>
        new(values, pageSize, pageIndex);
}
