using System.Xml.Serialization;

namespace XMLSamples
{
    public class SerializeViewModel
    {
        public SerializeViewModel()
        {
            Path = "../../../../../Xml/";
            XmlFileName = $"{Path}Product.xml";
        }

        private readonly string Path;
        private readonly string XmlFileName;

        #region SerializeProduct Method
        /// <summary>
        /// Use XmlSerializer and StringWriter
        /// </summary>
        public string SerializeProduct()
        {
            string value = string.Empty;

            // Create a New Product Object
            Product prod = new()
            {
                ProductID = 999,
                Name = "A New Product",
                ProductNumber = "NEW-999",
                Color = "White",
                StandardCost = 10,
                ListPrice = 20,
                Size = "Medium",
                ModifiedDate = Convert.ToDateTime("01-01-2022")
            };

            // TODO: Create XML Serializer
            var serializer = new XmlSerializer(typeof(Product));

            // Create a StringWriter to write product object into
            using (StringWriter sw = new())
            {
                // TODO: Serialize the product object to the StringWriter
                serializer.Serialize(sw, prod);

                // TODO: Get the serialized object as a string
                value = sw.ToString();

            }

            // Write to File
            File.WriteAllText(XmlFileName, value);

            // Display XML
            Console.WriteLine(value);

            return value;
        }
        #endregion

        #region DeserializeProduct Method
        /// <summary>
        /// Use XmlSerializer and StringReader to deserialize an XML document into a Product object
        /// </summary>
        public Product DeserializeProduct()
        {
            Product prod = null;
            string value = string.Empty;

            // TODO: Read from File
            value = File.ReadAllText(XmlFileName);

            // TODO: Create XML Serializer
            var serializer = new XmlSerializer(typeof(Product));

            // Create a StringReader with the value from the file
            using (StringReader sr = new(value))
            {
                // TODO: Convert the string to a product
                prod = (Product)serializer.Deserialize(sr);
            }

            // Display Product
            Console.WriteLine(prod);

            return prod;
        }
        #endregion
    }
}
