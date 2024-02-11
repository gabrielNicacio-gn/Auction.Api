using Auction.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Repositories
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions options)
           : base(options) { }

        public DbSet<Entities.Auction> Auctions { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<Offer>  Offers { get; set; }
    }
}
