using Auction.Api.Entities;
using Auction.Api.Interfaces;
using Auction.Api.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Auction.Api.UseCase.Auctions.GetCurrents
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepositories _repositories;  
        public GetCurrentAuctionUseCase(IAuctionRepositories repositories)
        {
            _repositories = repositories;
        }
        public async Task<Entities.Auction?> Execute() 
        {
           return await _repositories.GetCurrentAuction();
        }
    }
}
