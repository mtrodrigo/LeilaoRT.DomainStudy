using LeilaoRT.DomainStudy.Entities;
using LeilaoRT.DomainStudy.ValueObjects;
using LeilaoRT.DomainStudy.Enums;

namespace LeilaoRT.DomainStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Location location = new Location("MG", "Paraguaçu");
            Category category = new Category() 
            { 
                Name = "Motocicleta" 
            };

            Auction leilao1 = new Auction("Leilão Detran-MG", "Detran-MG", new DateTime(2026, 11, 16), location);

            Item honda = (new Item(80, "CG Titan 150 2012", 5000, 12000, 5800, category, location, leilao1));
            Item yamaha = (new Item(82, "Yamaha YBR 125cc 2008", 3500, 8000, 3600, category, location, leilao1));

            ItemCost titanCost1 = new ItemCost("Tranferência", 350, CostNature.Estimated);
            ItemCost titanCost2 = new ItemCost("Manutenção", 800, CostNature.Estimated);

            try
            {
                  leilao1.AddItem(honda);
                  leilao1.AddItem(yamaha);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Título do leilão: {leilao1.Title}");
            Console.WriteLine($"Cidade/UF: {leilao1.Location.CityName}/{leilao1.Location.StateCode}");
            Console.WriteLine($"Quantidade de itens: {leilao1.Items.Count}");

            foreach (Item item in leilao1.Items)
            {
                Console.WriteLine($"Lote: {item.LotNumber} - Item: {item.Title} - Lance máximo: {item.ReferenceValue} - Valor de venda: {item.EstimatedSaleValue}");
            }


        }
    }
}
