using System.Xml.Linq;

namespace XMLSamples
{
    /// <summary>
    /// Demos of how to add, edit and delete nodes from an XML document
    /// </summary>
    public class AddEditDeleteViewModel
    {
        #region AddNewNode Method
        /// <summary>
        /// Write code to create a new XElement object and add it to an existing XML document
        /// </summary>
        public XDocument AddNewNode()
        {
            // Get a Product XML string
            string xml = XmlStringHelper.CreateProductXmlString();
            // Create XML Document using Parse()
            XDocument doc = XDocument.Parse(xml);

            var elementToAdd = new XElement("Product",
                new XElement("ProductID", "745"),
                new XElement("Name", "HL Mountain Frame"),
                new XElement("ProductNumber", "FR-M94B-48"),
                new XElement("Color", "Black"),
                new XElement("StandardCost", "699.09"),
                new XElement("ListPrice", "1349.6000"),
                new XElement("Size", "48")
                );

            doc.Root.Add(elementToAdd);

            // Display Document
            Console.WriteLine(doc);

            return doc;
        }
        #endregion

        #region UpdateNode Method
        /// <summary>
        /// Write code to retrieve a single node from a document, edit some elements, then display the changed elements
        /// </summary>
        public XElement UpdateNode()
        {
            // Get a Product XML string
            string xml = XmlStringHelper.CreateProductXmlString();
            // Create XML Document using Parse()
            XDocument doc = XDocument.Parse(xml);

            XElement firstProductElement = doc.Root.Descendants().FirstOrDefault();

            if (firstProductElement != null)
            {
                firstProductElement.Element("Name").Value = "CHANGED PRODUCT";
                firstProductElement.Element("ListPrice").Value = "999.99";
            }

            Console.WriteLine(doc);

            return firstProductElement;
        }
        #endregion

        #region DeleteNode Method
        /// <summary>
        /// Write code to locate a specific node, then delete that node from the XML document
        /// </summary>
        public XElement DeleteNode()
        {
            // Get a Product XML string
            string xml = XmlStringHelper.CreateProductXmlString();
            // Create XML Document using Parse()
            XDocument doc = XDocument.Parse(xml);

            XElement elem = doc.Root.Descendants().FirstOrDefault();

            if (elem != null)
            {
                elem.Remove();
            }

            // Display Document
            Console.WriteLine(doc);

            return elem;
        }
        #endregion
    }
}
