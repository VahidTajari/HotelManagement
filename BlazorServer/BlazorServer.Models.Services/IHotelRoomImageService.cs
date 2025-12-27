using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer.Models.Services;
public interface IHotelRoomImageService : IDisposable
{
    public Task<int> CreateHotelRoomImageAsync(HotelRoomImageDTO imageDTO);
    public Task<int> DeleteHotelRoomImageByImageIdAsync(int imageId);
    public Task<int> DeleteHotelRoomImageByRoomIdAsync(int roomId);
    public Task<List<HotelRoomImageDTO>> GetHotelRoomImagesAsync(int roomId);
}
