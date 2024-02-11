using Auction.Api.Entities;

namespace Auction.Api.Interfaces
{
    public interface IUserRepositories
    {
        Task<User> GetUserLogged(string email);
        Task<bool> ExistUserWithEmail(string email);
    }
}