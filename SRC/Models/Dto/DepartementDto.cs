namespace StartUpApi.Models.Dto;

public class DepartementDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? AdminId { get; set; }

    public UserDto? Admin { get; set; }
}