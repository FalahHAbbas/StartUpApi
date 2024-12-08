namespace StartUpApi.Models.Dto;

public class Page<T>
{
    public List<T> Items { get; set; }
    public int PageCount { get; set; } = 0;
    public int CurrentPage { get; set; }
}