using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Models.Services;

public interface IHotelRoomService : IDisposable
{
    public Task<HotelRoomDto> CreateHotelRoomAsync(HotelRoomDto hotelRoomDto);
    public Task<int> DeleteHotelRoomAsync(int roomId);

    public IAsyncEnumerable<HotelRoomDto> GetAllHotelRoomsAsync();

    public Task<HotelRoomDto> GetHotelRoomAsync(int roomId);

    public Task<HotelRoomDto> UpdateHotelRoomAsync(int roomId, HotelRoomDto hotelRoomDto);
    public Task<HotelRoomDto> IsRoomUniqueAsync(string name);
    public Task<bool> IsRoomUniqueAsync(string name, int roomId);
}
