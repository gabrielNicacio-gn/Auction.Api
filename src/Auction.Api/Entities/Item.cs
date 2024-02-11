using Auction.Api.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Api.Entities
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public Condition Condition { get; set; }
        public decimal BasePrice { get; set; }
        public int AuctionId { get; set; }
    }
}
