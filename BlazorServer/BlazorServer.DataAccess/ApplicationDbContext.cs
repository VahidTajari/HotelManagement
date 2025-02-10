using BlazorServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.DataAccess;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<HotelRoom> HotelRooms { get; set; }
}
