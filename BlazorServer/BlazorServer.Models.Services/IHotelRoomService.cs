using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Models.Services;

public interface IHotelRoomService
{
    Task<HotelRoomDto> CreateHotelRoomAsync(HotelRoomDto hotelRoomDto);

    Task<int> DeleteHotelRoomAsync(int roomId);

    IAsyncEnumerable<HotelRoomDto> GetAllHotelRoomsAsync();

    Task<HotelRoomDto> GetHotelRoomAsync(int roomId);

    Task<HotelRoomDto> IsRoomUniqueAsync(string name);

    Task<HotelRoomDto> UpdateHotelRoomAsync(int roomId, HotelRoomDto hotelRoomDto);
}
