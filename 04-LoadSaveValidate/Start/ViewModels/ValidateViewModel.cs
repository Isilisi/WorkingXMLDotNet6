using System.Xml.Linq;
using System.Xml.Schema;

namespace XMLSamples
{
    /// <summary>
    /// Demos of validating an XML document using an XML schema
    /// </summary>
    public class ValidateViewModel
    {
        public ValidateViewModel()
        {
            XmlFileName = FileNameHelper.ProductsFile;
            XsdFile = FileNameHelper.ProductsXsdFile;
        }

        private readonly string XmlFileName;
        private readonly string XsdFile;

        #region ValidateXml Method
        /// <summary>
        /// Write code to validate XML using an XSD file
        /// </summary>
        public XDocument ValidateXml()
        {
            XDocument doc = XDocument.Load(XmlFileName);

            XmlSchemaSet xmlSchemaSet = new();
            xmlSchemaSet.Add("", XsdFile);

            doc.Validate(xmlSchemaSet, (sender, e) =>
            {
                Console.WriteLine(e.ToString());
            });

            Console.WriteLine("XML is valid.");

            return doc;
        }
        #endregion

        #region ValidateXmlWithError Method
        /// <summary>
        /// Write code to create an invalid node, then validate the XML using an XSD file
        /// </summary>
        public XDocument ValidateXmlWithError()
        {
            XDocument doc = XDocument.Load(XmlFileName);

            XmlSchemaSet xmlSchemaSet = new();
            xmlSchemaSet.Add("", XsdFile);

            XElement elem = new("Customer",
                new XElement("CustomerID", "999"),
                new XElement("CustomerName", "Invalid Customer")
                );
            doc.Root.AddFirst(elem);

            bool errors = false;
            doc.Validate(xmlSchemaSet, (sender, e) =>
            {
                if (e.Severity == XmlSeverityType.Error)
                {
                    errors = true;
                    Console.WriteLine($"Error: {e.Message}");
                }
                if (e.Severity == XmlSeverityType.Warning)
                {
                    errors = true;
                    Console.WriteLine($"Warning: {e.Message}");
                }
            });


            if (!errors)
            {
                // Display Success Message
                Console.WriteLine("XML is valid.");
            }

            return doc;
        }
        #endregion
    }
}
