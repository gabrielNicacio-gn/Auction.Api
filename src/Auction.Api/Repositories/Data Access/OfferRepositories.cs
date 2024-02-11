using Auction.Api.Entities;
using Auction.Api.Interfaces;

namespace Auction.Api.Repositories.Data_Access
{
    public class OfferRepositories : IOfferRepositories
    {
        private readonly AuctionDbContext _context;
        public OfferRepositories(AuctionDbContext context)
        {
            _context = context;
        }
        public async Task CreateNewOffer(Offer newOffer)
        {
            await _context.Offers.AddAsync(newOffer);
            await _context.SaveChangesAsync();
        }
    }
}
