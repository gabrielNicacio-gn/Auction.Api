using Auction.Api.Interfaces;
using Bogus;
using Moq;
using Auction.Api.Comunication.Request;
using Auction.Api.Entities;
using Auction.Api.UseCase.Offers.CreateOffer;
using Xunit;
using FluentAssertions;

namespace UseCases.Test.Offer.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(2)]
        public async Task CreateNewOfferSucess(int itemId)
        {
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request=>request.Price,f=>f.Random.Decimal());

            var loggedUserMock = new Mock<ILoggedUser>();
            loggedUserMock.Setup(mock=>mock.User()).ReturnsAsync(new User());
            var offerRepositoriesMock = new Mock<IOfferRepositories>();
            var useCase = new CreateOfferUseCase(offerRepositoriesMock.Object,loggedUserMock.Object);

            var func = async () => await useCase.Execute(itemId,request);

           await func.Should().NotThrowAsync();
        }
    }
}
