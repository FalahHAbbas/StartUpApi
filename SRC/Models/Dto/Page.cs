namespace StartUpApi.Models.Dto;

public class Page<T>
{
    public List<T> Items { get; set; }
    public int PageCount { get; set; } = 0;
    public int CurrentPage { get; set; }

    public Page()
    {
    }

    public Page(
        (List<T> items, int totalCount) data,
        int pageSize,
        int currentPage
    )
    {
        Items = data.items;
        PageCount = (data.totalCount - 1) / pageSize + 1;
        CurrentPage = pageSize;
    }
}