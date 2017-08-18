using Microsoft.AspNetCore.Identity;
using coreauthtest.Model;
using System;
using System.Threading.Tasks;

namespace coreauthtest.Infrastructure
{
    public class TotpAuthTokenProvider : IUserTokenProvider<IdentityUser>
    {
        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateAsync(string purpose, UserManager<IdentityUser> manager, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<IdentityUser> manager, IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }

}