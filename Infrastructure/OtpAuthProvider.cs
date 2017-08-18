using Microsoft.AspNetCore.Identity;
using coreauthtest.Model;
using System;
using System.Threading.Tasks;
using OtpSharp;

namespace coreauthtest.Infrastructure
{
    public class TotpAuthTokenProvider : IUserTokenProvider<ApplicationUser>
    {
        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            return Task.FromResult(user.IsTotpEnabled);
        }

        public Task<string> GenerateAsync(string purpose, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            return Task.FromResult((string)null);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            long timeStepMatched = 0;

            var otp = new Totp(Base64Encoder.Decode(user.ToptSecretKey));
            bool valid = otp.VerifyTotp(token, out timeStepMatched, new VerificationWindow(2, 2));

            return Task.FromResult(valid);
        }
    }

}