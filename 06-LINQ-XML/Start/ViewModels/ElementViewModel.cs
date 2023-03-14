using System.Xml.Linq;

namespace XMLSamples
{
    /// <summary>
    /// Demos of using element-based XML documents
    /// </summary>
    public class ElementViewModel
    {
        public ElementViewModel()
        {
            XmlFileName = FileNameHelper.ProductsFile;
        }

        private readonly string XmlFileName;

        #region GetAllXDocument Method
        /// <summary>
        /// When loading an XML document using XDocument, you use Descendants() to get all product nodes
        /// </summary>
        public List<XElement> GetAllXDocument()
        {
            XDocument doc = XDocument.Load(XmlFileName);
            List<XElement> list = doc.Descendants("Product").ToList();

            foreach (XElement prod in list)
            {
                Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
                Console.WriteLine($"   Product Id: {prod.GetAs<int>("ProductID")}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Products: {list.Count}");

            return list;
        }
        #endregion

        #region GetAllXElement Method
        /// <summary>
        /// When loading an XML document using XElement, you use Elements() to get all product nodes
        /// </summary>
        public List<XElement> GetAllXElement()
        {
            XElement elem = XElement.Load(XmlFileName);
            List<XElement> list = elem.Elements("Product").ToList();

            foreach (XElement prod in list)
            {
                Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
                Console.WriteLine($"   Product Id: {prod.GetAs<int>("ProductID")}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Products: {list.Count}");

            return list;
        }
        #endregion

        #region WhereClause Method
        /// <summary>
        /// Write a LINQ query to get a set of orders using a where clause from the XML file
        /// </summary>
        public List<XElement> WhereClause()
        {
            XElement elem = XElement.Load(XmlFileName);
            List<XElement> list = elem.Elements("Product").Where(p => p.GetAs<string>("Color") == "Silver").ToList();

            foreach (XElement prod in list)
            {
                Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
                Console.WriteLine($"   Product Id: {prod.GetAs<int>("ProductID")}");
                Console.WriteLine($"   Color: {prod.GetAs<string>("Color")}");
                Console.Write($"   Cost: {prod.GetAs<decimal>("StandardCost", 0):c}");
                Console.WriteLine($"   Price: {prod.GetAs<decimal>("ListPrice", 0):c}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Products: {list.Count}");

            return list;
        }
        #endregion

        #region GetASingleNode Method
        /// <summary>
        /// Write a LINQ query to get a single product from the XML file
        /// </summary>
        public XElement GetASingleNode()
        {
            XElement elem = XElement.Load(XmlFileName);
            XElement product = elem.Elements("Product").Where(p => p.GetAs<int>("ProductID") == 706).FirstOrDefault();

            if (product != null)
            {
                Console.WriteLine($"Product Name: {product.GetAs<string>("Name")}");
                Console.WriteLine($"   Product Id: {product.GetAs<int>("ProductID")}");
                Console.WriteLine($"   Color: {product.GetAs<string>("Color")}");
                Console.Write($"   Cost: {product.GetAs<decimal>("StandardCost", 0):c}");
                Console.WriteLine($"   Price: {product.GetAs<decimal>("ListPrice", 0):c}");
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }

            return product;
        }
        #endregion

        #region OrderBy Method
        /// <summary>
        /// Write a LINQ query to get all products ordering by Color, ListPrice
        /// </summary>
        public List<XElement> OrderBy()
        {
            XElement elem = XElement.Load(XmlFileName);
            List<XElement> list = elem.Elements("Product").OrderBy(p => p.GetAs<string>("Color")).ThenBy(p => p.GetAs<decimal>("ListPrice", 0)).ToList();

            foreach (XElement prod in list)
            {
                Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
                Console.WriteLine($"   Color: {prod.GetAs<string>("Color")}");
                Console.WriteLine($"   Price: {prod.GetAs<decimal>("ListPrice", 0):c}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Products: {list.Count}");

            return list;
        }
        #endregion

        #region AddToClass Method
        /// <summary>
        /// Write a LINQ query to get all elements and build a collection of Product objects
        /// </summary>
        public List<Product> AddToClass()
        {
            XElement elem = XElement.Load(XmlFileName);
            List<Product> list = elem.Elements("Product").Select(p => new Product
            {
                ProductID = p.GetAs<int>("ProductID"),
                Name = p.GetAs<string>("Name", "N/A"),
                Color = p.GetAs<string>("Color"),
                StandardCost = p.GetAs<decimal>("StandardCost", 0),
                ListPrice = p.GetAs<decimal>("ListPrice", 0),
                Size = p.GetAs<string>("SalesPerson", "N/A")
            }).ToList();

            // Display products
            foreach (Product prod in list)
            {
                Console.Write(prod);
            }

            Console.WriteLine();
            Console.WriteLine($"Total Products: {list.Count}");

            return list;
        }
        #endregion

        #region Join Method
        /// <summary>
        /// Write code load two XML files to join products and orders and create a new XML document with a different shape.
        /// </summary>
        public XElement Join()
        {
            XElement prodElem;
            XElement detailElem;

            // Load products XML File
            prodElem = XElement.Load(XmlFileName);
            // Load Sales Order Detail XML File
            detailElem = XElement.Load(FileNameHelper.SalesOrderDetailsFile);

            XElement newDoc = new XElement("SalesOrderWithProductInfo", prodElem
                .Elements("Product")
                .Join(
                    detailElem.Elements("SalesOrderDetail"),
                    product => product.GetAs<int>("ProductID"),
                    order => order.GetAs<int>("ProductID"),
                    (product, order) => new XElement("Order",
                        new XElement("ProductID", product.GetAs<int>("ProductID")),
                        new XElement("Name", product.GetAs<string>("Name")),
                        new XElement("Color", product.GetAs<string>("Color")),
                        new XElement("ListPrice", product.GetAs<decimal>("ListPrice", 0)),
                        new XElement("Quantity", order.GetAs<decimal>("OrderQty", 0)),
                        new XElement("UnitPrice", order.GetAs<decimal>("UnitPrice", 0)),
                        new XElement("Total", order.GetAs<decimal>("LineTotal", 0))
                        )
                    )
                );
                    

            // Display Document
            Console.WriteLine(newDoc);

            return newDoc;
        }
        #endregion

        #region GetSalesWithDetails Method
        /// <summary>
        /// Write a LINQ query to only get those sales orders that have details
        /// </summary>
        public List<XElement> GetSalesWithDetails()
        {
            XElement elem = XElement.Load(FileNameHelper.SalesAndDetailsFile);
            List<XElement> list = elem
                .Elements("SalesOrderHeader")
                .Where(order => order.Element("SalesOrderDetails") is not null)
                .ToList();

            // Display Elements
            foreach (XElement order in list)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Total Items: {list.Count}");

            return list;
        }
        #endregion

        #region GetSalesLineTotalGreaterThan Method
        /// <summary>
        /// Write a LINQ query to only get those orders that have a LineTotal > $5,000
        /// </summary>
        public List<XElement> GetSalesLineTotalGreaterThan()
        {
            XElement elem = XElement.Load(FileNameHelper.SalesAndDetailsFile);
            List<XElement> list = elem
                .Elements("SalesOrderHeader")
                .Where(order => order.Element("SalesOrderDetails") is not null)
                .Where(order => order.Elements("SalesOrderDetail").Select(x => x.GetAs<decimal>("LineTotal")).Sum() > 5)
                .ToList();

            // Display Elements
            foreach (XElement order in list)
            {
                Console.WriteLine(order);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Total Items: {list.Count}");

            return list;
        }
        #endregion
    }
}
