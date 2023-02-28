using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XMLSamples
{
    /// <summary>
    /// Demos for saving an XML document to disk
    /// </summary>
    public class SaveViewModel
    {
        public SaveViewModel()
        {
            // TODO: Modify your file location
            XmlFilePath = $"{FileNameHelper.Path}";
        }

        private readonly string XmlFilePath;

        #region SaveUsingXDocument Method
        /// <summary>
        /// Write code to save an XML document to disk using XDocument.Save()
        /// </summary>
        public string SaveUsingXDocument()
        {
            // Get a Product XML string
            string xml = XmlStringHelper.CreateProductXmlString();
            // Create XML Document using Parse()
            XDocument doc = XDocument.Parse(xml);

            doc.Save($"{XmlFilePath}{nameof(SaveUsingXDocument)}.xml", SaveOptions.DisableFormatting);

            // Display value
            string value = $"Check the file '{nameof(SaveUsingXDocument)}.xml' for the XML document";
            Console.WriteLine(value);

            return value;
        }
        #endregion

        #region SaveUsingXmlWriter Method
        /// <summary>
        /// Create XML document and save to disk using the XmlWriter class
        /// </summary>
        public string SaveUsingXmlWriter()
        {
            // Create the XML Writer
            using (XmlWriter writer = XmlWriter.Create($"{XmlFilePath}{nameof(SaveUsingXmlWriter)}.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Products");
                writer.WriteStartElement("Product");
                writer.WriteAttributeString("ProductID", "999");
                writer.WriteStartElement("Name");
                writer.WriteString("Bicycle Helmet");

                // Close the Writer
                writer.Close();
            }

            // Display value
            string value = $"Check the file '{nameof(SaveUsingXmlWriter)}.xml' for the XML document";
            Console.WriteLine(value);

            return value;
        }
        #endregion

        #region XmlWriterFormattingSave Method
        /// <summary>
        /// Create XML document and save to disk using the XmlWriter class
        /// Use the XmlWriterSettings object to specify formatting for the XML
        /// </summary>
        public string XmlWriterFormattingSave()
        {
            // TODO: Write your code here
            XmlWriterSettings settings = new()
            {
                Encoding = Encoding.Unicode,
                Indent = true
            };

            // Create the XML Writer
            using (XmlWriter writer = XmlWriter.Create($"{XmlFilePath}{nameof(XmlWriterFormattingSave)}.xml", settings))
            {
                // Write a Start Element (Root)
                writer.WriteStartElement("Products");

                // Write a Start Element (Parent)
                writer.WriteStartElement("Product");
                // Write an Attribute
                writer.WriteAttributeString("ProductID", "999");

                // Write a Start Element (Child)
                writer.WriteStartElement("Name");
                // Write the value
                writer.WriteString("Bicycle Helmet");
                // Write the End Element
                writer.WriteEndElement();

                // Write a Start Element (Child)
                writer.WriteStartElement("ProductNumber");
                // Write the value
                writer.WriteString("HELM-01");
                // Write the End Element
                writer.WriteEndElement();

                // Write a Start Element (Child)
                writer.WriteStartElement("Color");
                // Write the value
                writer.WriteString("White");
                // Write the End Element
                writer.WriteEndElement();

                // Write a Start Element (Child)
                writer.WriteStartElement("StandardCost");
                // Write the value
                writer.WriteString("24.49");
                // Write the End Element
                writer.WriteEndElement();

                // Write a Start Element (Child)
                writer.WriteStartElement("ListPrice");
                // Write the value
                writer.WriteString("89.99");
                // Write the End Element
                writer.WriteEndElement();

                // Write a Start Element (Child)
                writer.WriteStartElement("Size");
                // Write the value
                writer.WriteString("Medium");
                // Write the End Element
                writer.WriteEndElement();

                // Write the End Element (Parent)
                writer.WriteEndElement();
                // Write the End Element (Root)
                writer.WriteEndElement();
                // Close the Writer
                writer.Close();
            }

            // Display value
            string value = $"Check the file '{nameof(XmlWriterFormattingSave)}.xml' for the XML document";
            Console.WriteLine(value);

            return value;
        }
        #endregion

        #region DataSetSave Method
        /// <summary>
        /// Put data into a DataSet object from a SQL database, then write the XML and XSD to disk using the WriteXml() and WriteXmlSchema() methods
        /// </summary>
        public string DataSetSave()
        {
            string sql = "SELECT * FROM Product";
            string connectionString = @"Server=(localdb)\mssqllocaldb;Initial Catalog=XmlSample;Integrated Security=true";

            using (SqlDataAdapter dataAdapter = new(sql, connectionString))
            {
                // Set the DataSetName = Root Node
                using (DataSet dataSet = new("Products"))
                {
                    // Set TableName = Parent Nodes
                    dataAdapter.Fill(dataSet, "Product");

                    using (StreamWriter xmlWriter = new($"{XmlFilePath}{nameof(DataSetSave)}.xml", false, Encoding.Unicode))
                    {
                        dataSet.WriteXml(xmlWriter);
                    }

                    using (StreamWriter xsdWriter = new($"{XmlFilePath}{nameof(DataSetSave)}.xsd", false, Encoding.Unicode))
                    {
                        dataSet.WriteXmlSchema(xsdWriter);
                    }
                }
            }

            string value = $"Check the file '{nameof(DataSetSave)}.xml' for the XML document";
            value += $"{Environment.NewLine}Check the file '{nameof(DataSetSave)}.xsd' for the XSD document";

            // Display value
            Console.WriteLine(value);

            return value;
        }
        #endregion
    }
}
