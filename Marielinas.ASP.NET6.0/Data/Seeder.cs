using Marielinas.ASP.NET6._0.Models;
using Marielinas.ASP.NET6._0.Repository;
using Microsoft.AspNetCore.Identity;

namespace Marielinas.ASP.NET6._0.Data
{
    public class Seeder
    {
        private readonly AppDbContext _context;
        private readonly UserManager<StoreUser> _userManager;

        public Seeder(AppDbContext Context, UserManager<StoreUser> UserManager)
        {
            _context = Context;
            _userManager = UserManager;
        }

        public async Task SeedAsync() {

            _context.Database.EnsureCreated();
            StoreUser user = await _userManager.FindByEmailAsync("rihan@gmail.com");
            if (user == null) {
                user = new StoreUser() { 
                FirstName="Rihan",
                LastName="Zamil",
                Email="rihan@gmail.com",
                UserName="rihan@gmail.com"               
                };

                var result = await _userManager.CreateAsync(user, "Ahmed@123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could Not Create User in DB");
                }
            
            }

        }
    }
}
