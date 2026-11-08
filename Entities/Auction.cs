using LeilaoRT.DomainStudy.Enums;
using LeilaoRT.DomainStudy.ValueObjects;

namespace LeilaoRT.DomainStudy.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Organizer { get; set; }
        public DateTime AuctionDate { get; set; }
        public AuctionStatus Status { get; set; }
        public Location Location { get; set; }

        public List<Item> Items { get; set; } = new();

        public Auction( string title,
                        string organizer,
                        DateTime auctionDate,
                        Location location) 
        {
            Title = title;
            Organizer = organizer;
            AuctionDate = auctionDate;
            Location = location;
            Status = AuctionStatus.Planned;
        }

    }
}
