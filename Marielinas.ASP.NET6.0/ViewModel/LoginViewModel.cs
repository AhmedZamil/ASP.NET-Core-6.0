using System.ComponentModel.DataAnnotations;

namespace Marielinas.ASP.NET6._0.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
