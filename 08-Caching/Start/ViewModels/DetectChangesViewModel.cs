using System.Xml.Linq;

namespace XMLSamples
{
    /// <summary>
    /// Check if data on a database matches the data in an XML file.
    /// If the data does not match, then refresh the XML file.
    /// </summary>
    public class DetectChangesViewModel
    {
        public DetectChangesViewModel()
        {
            XmlFileName = "../../../../../Xml/ProductsCached.xml";
        }

        private readonly string XmlFileName;

        #region CompareData Method
        /// <summary>
        /// Get total rows and max date of ModifiedDate field in both XML file and database to determine if the XML file needs to be refreshed.
        /// </summary>
        public string CompareData()
        {
            string ret = "Local file is up to date";
            XElement elem = null;
            List<Product> products;
            ChangeInfo localInfo = new();
            ChangeInfo serverInfo = new();

            //**************************************
            // Get Local Info
            //**************************************
            // Get XML File as XElement object
            elem = XElement.Parse(File.ReadAllText(XmlFileName));

            // Get largest ModifiedDate in local XML file
            localInfo.MaxDate = elem.Elements("Product").Select(p => p.GetAs<DateTime>("ModifiedDate")).Max();

            // Get total rows in XML file
            localInfo.TotalRows = elem.Elements("Product").Count();


            //**************************************
            // Get Server Info
            //**************************************
            using (XMLSamplesDbContext db = new())
            {
                // Get maximum date in ModifiedDate field
                // SELECT MAX(ModifiedDate) FROM dbo.Product
                serverInfo.MaxDate = db.Products.Select(p => p.ModifiedDate).Max();

                // Get total rows on server
                // SELECT COUNT(*) FROM dbo.Product
                serverInfo.TotalRows = db.Products.Count();
            }

            //************************************************
            // Check if server date is greater than local date 
            // or total rows are not the same
            //************************************************
            if (localInfo.MaxDate < serverInfo.MaxDate ||
                localInfo.TotalRows != serverInfo.TotalRows)
            {
                ret = "Local file was updated from the server";

                //**************************************
                // Store XML data to local file
                //**************************************
                using (XMLSamplesDbContext db = new())
                {
                    // Get all Products
                    products = db.Products.ToList();

                    // Serialize into local file
                    File.WriteAllText(XmlFileName, products.Serialize());
                };
            }

            Console.WriteLine(ret);

            return ret;
        }
        #endregion
    }
}
