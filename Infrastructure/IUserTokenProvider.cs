using Microsoft.AspNetCore.Identity;

namespace coreauthtest.Infrastructure
{

    public interface IUserTokenProvider<T> : IUserTwoFactorTokenProvider<T>
        where T: class
    {

    }
}

