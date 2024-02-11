using Auction.Api.Enums;
using Auction.Api.Interfaces;
using Auction.Api.UseCase.Auctions.GetCurrents;
using AutoFixture;
using Bogus;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public async Task GetCurrentAuctionSucess()
        {
            // Arrange
            var newAuction = new Faker<Auction.Api.Entities.Auction>()
                .RuleFor(auction=> auction.Id, f=> f.Random.Number(1,100))
                .RuleFor(auction=>auction.Name,f=>f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.ListItem, (f,auction) => new List<Auction.Api.Entities.Item>
                {
                    new Auction.Api.Entities.Item
                    {
                        Id = f.Random.Number(1,100),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var auctionRepositoriesMock = new Mock<IAuctionRepositories>();
            auctionRepositoriesMock.Setup(mock => mock.GetCurrentAuction()).ReturnsAsync(newAuction);

            var useCase = new GetCurrentAuctionUseCase(auctionRepositoriesMock.Object);
            //Act
            var auction = await useCase.Execute();

            //Assert
            auction.Should().NotBeNull();
            auction!.Id.Should().Be(newAuction.Id);
        }
    }
}
