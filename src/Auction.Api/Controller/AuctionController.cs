using Auction.Api.UseCase.Auctions.GetCurrents;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controller
{
    public class AuctionController : AuctionApiBaseController
    {
        private readonly GetCurrentAuctionUseCase _get;
        public AuctionController(GetCurrentAuctionUseCase get)
        {
            _get = get;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Entities.Auction),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetCurrentAuction()
        {
            var auction = await _get.Execute();
            if(auction is null) 
            {
                return NoContent();
            }
            return Ok(auction);
        }
    }
}
