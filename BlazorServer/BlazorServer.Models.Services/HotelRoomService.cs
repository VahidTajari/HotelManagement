using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorServer.DataAccess;
using BlazorServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Models.Services;
public class HotelRoomService : IHotelRoomService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IConfigurationProvider _mapperConfiguration;

    public HotelRoomService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mapperConfiguration = mapper.ConfigurationProvider;
    }

    public async Task<HotelRoomDto> CreateHotelRoomAsync(HotelRoomDto hotelRoomDto)
    {
        var hotelRoom = _mapper.Map<HotelRoom>(hotelRoomDto);
        hotelRoom.CreatedDate = DateTime.UtcNow;
        hotelRoom.CreatedBy = "";
        var addedHotelRoom = await _dbContext.HotelRooms.AddAsync(hotelRoom);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<HotelRoomDto>(addedHotelRoom.Entity);
    }

    public async Task<int> DeleteHotelRoomAsync(int roomId)
    {
        var roomDetails = await _dbContext.HotelRooms.FindAsync(roomId);
        if (roomDetails is null)
        {
            return 0;
        }

        _dbContext.HotelRooms.Remove(roomDetails);
        return await _dbContext.SaveChangesAsync();
    }

    public IAsyncEnumerable<HotelRoomDto> GetAllHotelRoomsAsync()
    {
        return _dbContext.HotelRooms
            .Include(x => x.HotelRoomImages)
                    .ProjectTo<HotelRoomDto>(_mapperConfiguration)
                    .AsAsyncEnumerable();
    }

    public Task<HotelRoomDto> GetHotelRoomAsync(int roomId)
    {
        return _dbContext.HotelRooms
            .Include(x => x.HotelRoomImages)
            .ProjectTo<HotelRoomDto>(_mapperConfiguration)
            .FirstOrDefaultAsync(x => x.Id == roomId);
    }
    public async Task<HotelRoomDto> UpdateHotelRoomAsync(int roomId, HotelRoomDto hotelRoomDto)
    {
        if (roomId != hotelRoomDto?.Id)
        {
            return null;
        }

        var roomDetails = await _dbContext.HotelRooms.FindAsync(roomId);
        var room = _mapper.Map(hotelRoomDto, roomDetails);
        room.UpdatedBy = "";
        room.UpdatedDate = DateTime.UtcNow;
        var updatedRoom = _dbContext.HotelRooms.Update(room);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<HotelRoomDto>(updatedRoom.Entity);
    }

    public Task<HotelRoomDto> IsRoomUniqueAsync(string name)
    {
        return _dbContext.HotelRooms
            .ProjectTo<HotelRoomDto>(_mapperConfiguration)
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<bool> IsRoomUniqueAsync(string name, int roomId)
    {
        if (roomId == 0)
        {
            // Create Mode
            var r = await _dbContext.HotelRooms.FirstOrDefaultAsync(x => x.Name == name);
            return r is null;
        }
        else
        {
            // Edit Mode

            var r = await _dbContext.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId && x.Name == name);
            return r is null;
        }
    }

    private bool _isDisposed;

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            try
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            finally
            {
                _isDisposed = true;
            }
        }
    }
}
