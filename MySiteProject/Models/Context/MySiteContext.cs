using Microsoft.EntityFrameworkCore;
using MySiteProject.Models.Entities;

namespace MySiteProject.Models.Context
{
    public class MySiteContext : DbContext
    {
        public MySiteContext()
        {

        }

        public MySiteContext(DbContextOptions<MySiteContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IKBAL\\MSSQLSERVER2019;Database=NRM1-MySiteDB;Trusted_Connection=True;");
        }

        public DbSet<AboutMe> AboutMes { get; set; }
        public DbSet<AdminTab> AdminTabs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ProjectInfo> ProjectInfos { get; set; }
    }
}
