namespace XMLSamples
{
    public class NestedViewModel
    {
        public NestedViewModel()
        {
            Path = "../../../../../Xml/";
            XmlFileName = $"{Path}ProductSales.xml";
        }

        private readonly string Path;
        private readonly string XmlFileName;

        #region SerializeProductSales Method
        /// <summary>
        /// Serialize a nested object to XML
        /// </summary>
        public string SerializeProductSales()
        {
            ProductSales prod = ProductSalesRepository.Get();
            string value = string.Empty;

            // TODO: Serialize the object
            value = prod.Serialize();

            // TODO: Write to File
            File.WriteAllText(XmlFileName, value);

            // Display Product
            Console.WriteLine(value);

            return value;
        }
        #endregion

        #region DeserializeProductSales Method
        /// <summary>
        /// Deserialize XML with nested elements back into a C# class
        /// </summary>
        public ProductSales DeserializeProductSales()
        {
            ProductSales prod = new();
            string value;

            // Read from File
            value = File.ReadAllText(XmlFileName);

            // TODO: Deserialize the object
            prod = prod.Deserialize(value);

            // Display Product
            Console.WriteLine(prod);

            return prod;
        }
        #endregion
    }
}
