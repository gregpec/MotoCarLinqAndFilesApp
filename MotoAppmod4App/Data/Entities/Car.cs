using System.Text;

namespace MotoAppmod4App.Data.Entities
{
    public class Car : EntityBase
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Type { get; set; }

        //Calculated Properties

        public int? NameLength { get; set; }

        public decimal? TotalSales { get; set; }

        # region ToString Override

        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"{Name} ID: {Id}");
            sb.AppendLine($"    Color {Color}   Type: {Type ?? "n/a"}");
            sb.AppendLine($"    Cost {StandardCost:p}   Price: {ListPrice:p}"); 
            if (NameLength.HasValue)
            {
                sb.AppendLine($"    Name Length:   {NameLength}");
            }
            if (TotalSales.HasValue)
            {
                sb.AppendLine($"    Total Sales: {TotalSales:c}");
            }
            return sb.ToString();
        }
    }
    #endregion
}

