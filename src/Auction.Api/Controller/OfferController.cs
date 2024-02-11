using Auction.Api.Comunication.Request;
using Auction.Api.Filters;
using Auction.Api.UseCase.Offers.CreateOffer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Api.Controller
{
    [ServiceFilter(typeof(AutenticationUserAttribute))]
    public class OfferController : ControllerBase
    {
        [HttpPost]
        [Route("{itemId}")]
        public async Task<IActionResult> CreateOffer(
            [FromRoute]int itemId, 
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var offerId = await useCase.Execute(itemId,request);
            return Created(string.Empty,offerId);
        }
    }
}
