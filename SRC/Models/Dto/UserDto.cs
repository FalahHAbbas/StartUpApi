namespace StartUpApi.Models.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;
}