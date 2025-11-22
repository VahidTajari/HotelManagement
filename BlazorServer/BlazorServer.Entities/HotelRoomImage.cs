namespace BlazorServer.Entities;
public class HotelRoomImage
{
    public int Id { get; set; }

    public string RoomImageUrl { get; set; }

    [ForeignKey("RoomId")]
    public virtual HotelRoom HotelRoom { get; set; }
    public int RoomId { get; set; }
}
