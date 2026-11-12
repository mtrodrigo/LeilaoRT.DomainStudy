using LeilaoRT.DomainStudy.Enums;

namespace LeilaoRT.DomainStudy.Entities
{
    public class ItemCost
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public CostNature Nature { get; set; }

        public ItemCost() { }

        public ItemCost(string description, 
                        decimal amount,
                        CostNature nature) 
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty", nameof(description));
            }

            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative", nameof(amount));
            }

            Description = description;
            Amount = amount;
            Nature = nature;
        }
    }
}
