using TI_Projekt.Models;

namespace TI_Projekt
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TripDbContext : DbContext
    {
        public TripDbContext()
            : base("name=TI")
        {
        }

        public DbSet<TripModel> Trips { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<VideoModel> Videos { get; set; }
    }
}