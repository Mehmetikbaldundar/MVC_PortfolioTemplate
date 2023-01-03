using Microsoft.EntityFrameworkCore;
using MySiteProject.Models.Context;
using MySiteProject.Models.Entities;

namespace MySiteProject.Models.SeedDataFolder
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<MySiteContext>();
            dbContext.Database.Migrate();

            if (dbContext.AdminTabs.Count() == 0)
            {
                dbContext.AdminTabs.Add(new AdminTab()
                {
                    Username = "admin",
                    Password = "admin",
                });
            }
            dbContext.SaveChanges();
        }
    }
}
