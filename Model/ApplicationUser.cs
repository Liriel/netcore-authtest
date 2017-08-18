
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace coreauthtest.Model{
    public class ApplicationUser : IdentityUser{

        public bool IsTotpEnabled { get; set; }

        public string ToptSecretKey { get; set; }
    }
}