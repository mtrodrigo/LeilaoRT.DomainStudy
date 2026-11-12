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

        public Auction() { }

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

        public void AddItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            foreach (var verifyLot in Items)
            {
                if(verifyLot.LotNumber == item.LotNumber)
                {
                    throw new ArgumentException("Lot number is already registered", nameof(item));
                }
            }

            Items.Add(item);
        }

    }
}
