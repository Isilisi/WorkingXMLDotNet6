﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XMLSamples
{
    [Table("Product", Schema = "dbo")]
    public partial class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public DateTime ModifiedDate { get; set; }

        #region ToString Override 
        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"{Name}  ID: {ProductID}");
            sb.AppendLine($"   Color: {Color ?? "n/a"}   Size: {Size ?? "n/a"}");
            sb.AppendLine($"   Cost: {StandardCost:c}   Price: {ListPrice:c}");
            sb.AppendLine($"   Modified Date: {ModifiedDate:d}");

            return sb.ToString();
        }
        #endregion
    }
}
