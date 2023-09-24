using HellowWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HellowWorld.Data{

public class DataContextEF : DbContext
 {

      public DbSet<Computer>? Computer { get; set; }
    private readonly string?  _connectionString;
    private readonly IConfiguration _configuration;
    
public DataContextEF( IConfiguration configuration){

      _configuration = configuration;
      _connectionString = configuration.GetConnectionString("DefaultConnection");

}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           if (!options.IsConfigured)
            {
                // options.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;Trusted_connection=false;TrustServerCertificate=True;User Id=sa;Password=SQLConnect1;",
                options.UseSqlServer( _connectionString,
                    options => options.EnableRetryOnFailure());
            }
        }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>()
                // .HasNoKey()
                .HasKey(c => c.ComputerId);
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("TableName", "SchemaName");
        }


    }

}