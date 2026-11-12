using LeilaoRT.DomainStudy.Enums;
using LeilaoRT.DomainStudy.ValueObjects;

namespace LeilaoRT.DomainStudy.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int LotNumber { get; set; }
        public string Title { get; set; }
        public decimal ReferenceValue { get; set; }
        public decimal EstimatedSaleValue { get; set; }
        public decimal PurchaseValue { get; set; }
        public Category Category { get; set; }
        public Location Location { get; set; }
        public ItemStatus Status { get; set; }
        public List<ItemCost> Costs { get; set; } = new();
        public Auction Auction { get; set; }

        public Item(){ }

        public Item(int lotNumber,
                    string title,
                    decimal referenceValue,
                    decimal estimatedSaleValue,
                    decimal purchaseValue,
                    Category category,
                    Location location,
                    Auction auction)
        {
            if (lotNumber <= 0)
            {
                throw new ArgumentException("Lot number must be greater than zero.", nameof(lotNumber));
            }

            if (referenceValue < 0)
            {
                throw new ArgumentException("Reference value cannot be negative.", nameof(referenceValue));
            }

            if (estimatedSaleValue < 0)
            {
                throw new ArgumentException("Estimated sale value cannot be negative.", nameof(estimatedSaleValue));
            }
            if (purchaseValue < 0)
            {
                throw new ArgumentException("Purchase value cannot be negative", nameof(purchaseValue));
            }

            LotNumber = lotNumber;
            Title = title;
            ReferenceValue = referenceValue;
            EstimatedSaleValue = estimatedSaleValue;
            PurchaseValue = purchaseValue;
            Category = category;
            Location = location;
            Status = ItemStatus.EmAnalise;
            Auction = auction;
        }

        public decimal CalculateTotalCosts() 
        {
            decimal total = 0;
            foreach (ItemCost cost in Costs)
            {
                total += cost.Amount;
            }
            return total;
        }

        public decimal CalculateTotalInvestment() 
        {
            return PurchaseValue + CalculateTotalCosts();
        }

        public decimal CalculateEstimatedProfit()
        {
            return EstimatedSaleValue - CalculateTotalInvestment();
        }

        public decimal CalculateEstimatedRoi()
        {
            decimal totalInvestment = CalculateTotalInvestment();
            if (totalInvestment == 0)
            {
                return 0;
            }
            decimal total = CalculateEstimatedProfit() / totalInvestment * 100;
            return total;
        }
    }
}
