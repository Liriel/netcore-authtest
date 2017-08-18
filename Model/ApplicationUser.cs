
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace coreauthtest.Model{
    public class ApplicationUser : IdentityUser{

        public bool IsGoogleAuthenticatorEnabled { get; set; }

        public string GoogleAuthenticatorSecretKey { get; set; }
    }
}