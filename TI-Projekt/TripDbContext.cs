using TI_Projekt.Models;

namespace TI_Projekt
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TripDbContext : DbContext
    {
        // Your context has been configured to use a 'TripDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TI_Projekt.TripDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TripDbContext' 
        // connection string in the application configuration file.
        public TripDbContext()
            : base("name=TI")
        {
        }

        public DbSet<TripModel> Trips { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<VideoModel> Videos { get; set; }
    }
}