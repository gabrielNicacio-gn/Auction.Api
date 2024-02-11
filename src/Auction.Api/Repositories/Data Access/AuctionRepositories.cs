using Auction.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Repositories.Data_Access
{
    public class AuctionRepositories : IAuctionRepositories
    {
        private readonly AuctionDbContext _context;
        public AuctionRepositories(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.Auction?> GetCurrentAuction()
        {
            var today = DateTime.Now;
            return await _context.Auctions
                .Include(list => list.ListItem)
                .Where(auction => today >= auction.Starts && today <= auction.Ends)
                .FirstOrDefaultAsync();
        }
    }
}
