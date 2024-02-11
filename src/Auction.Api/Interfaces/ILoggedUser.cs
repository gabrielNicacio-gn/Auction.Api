using Auction.Api.Entities;

namespace Auction.Api.Interfaces
{
    public interface ILoggedUser
    {
        Task<User> User();
    }
}