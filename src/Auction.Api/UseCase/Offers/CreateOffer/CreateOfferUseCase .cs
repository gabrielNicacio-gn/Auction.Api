using Auction.Api.Comunication.Request;
using Auction.Api.Entities;
using Auction.Api.Interfaces;
using Auction.Api.Repositories;
using Auction.Api.Services;

namespace Auction.Api.UseCase.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly IOfferRepositories _repositories;
        private readonly ILoggedUser _loggedUser;
        public CreateOfferUseCase(IOfferRepositories repositories ,ILoggedUser loggedUser)
        {
            _repositories = repositories;
            _loggedUser = loggedUser;
        }
        public async Task<int> Execute(int itemId, RequestCreateOfferJson request)
        {
            var user = await _loggedUser.User();
            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };
             await _repositories.CreateNewOffer(offer);

            return offer.Id;
        }
    }
}
