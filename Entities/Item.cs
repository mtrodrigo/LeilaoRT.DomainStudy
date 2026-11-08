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

        public Category Category { get; set; }
        public Location Location { get; set; }

        public Item(int lotNumber,
                    string title,
                    decimal referenceValue,
                    decimal estimatedSaleValue,
                    Category category,
                    Location location)
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

            LotNumber = lotNumber;
            Title = title;
            ReferenceValue = referenceValue;
            EstimatedSaleValue = estimatedSaleValue;
            Category = category;
            Location = location;
        }
    }
}
