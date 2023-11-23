using Microsoft.EntityFrameworkCore;
using AppointmentScheduling.Entities;
using Microsoft.Extensions.Configuration;

namespace AppointmentScheduling.DAL
{
    public class AppointmentDbContext:DbContext
    {
        public IConfiguration Configuration { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AppointmentDBConn"));
                optionsBuilder.UseSqlServer("Data Source=testpoc\\SQLEXPRESS;Initial Catalog=AppointmentSchedulingDB;Persist Security Info=True;User ID=testpoc\testpocuser;Password=Aws@techie123");
            }
        }
        public AppointmentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Appointment> Appointment { get; set; } = null!;
    }
}