using Auction.Api.Entities;
using Auction.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Repositories.Data_Access
{
    public class UserRepositories : IUserRepositories
    {
        private readonly AuctionDbContext _repository;
        public UserRepositories(AuctionDbContext repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserLogged(string email)
        {
            var user = await _repository.Users
                .Where(user => user.Email.Equals(email))
                .FirstAsync();
            return user;
        }
        public async Task<bool> ExistUserWithEmail(string email)
        {
            var exist =  await _repository.Users.AnyAsync(user => user.Email.Equals(email));
            return exist;
        }
    }
}
