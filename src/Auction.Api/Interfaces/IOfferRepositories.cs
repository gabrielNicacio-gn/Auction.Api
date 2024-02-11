using Auction.Api.Entities;

namespace Auction.Api.Interfaces
{
    public interface IOfferRepositories
    {
        Task CreateNewOffer(Offer newOffer);
    }
}