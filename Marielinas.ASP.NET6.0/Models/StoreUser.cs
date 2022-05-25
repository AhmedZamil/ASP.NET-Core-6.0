using Microsoft.AspNetCore.Identity;

namespace Marielinas.ASP.NET6._0.Models
{
    public class StoreUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
