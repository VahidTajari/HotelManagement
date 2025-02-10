namespace BlazorServer.Models;

public record HotelRoomDto
{
    public int Id { get; init; }

    [Required(ErrorMessage = "Please enter the room's name")]
    public string Name { get; init; }

    [Required(ErrorMessage = "Please enter the occupancy")]
    public int Occupancy { get; init; }

    [Range(1, 3000, ErrorMessage = "Regular rate must be between 1 and 3000")]
    public decimal RegularRate { get; init; }

    public string Details { get; init; }

    public string SqFt { get; init; }
}
