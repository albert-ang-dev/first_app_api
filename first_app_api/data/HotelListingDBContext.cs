using Microsoft.EntityFrameworkCore;

namespace first_app_api.data
{
    public class HotelListingDBContext: DbContext
    {
        
        public HotelListingDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
