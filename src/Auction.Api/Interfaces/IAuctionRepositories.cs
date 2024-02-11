namespace Auction.Api.Interfaces
{
    public interface IAuctionRepositories
    {
        Task<Entities.Auction?> GetCurrentAuction();
    }
}