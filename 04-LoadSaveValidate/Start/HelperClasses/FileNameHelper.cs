namespace XMLSamples
{
    /// <summary>
    /// Provides properties pointing to the various XML files used in this course
    /// </summary>
    public static class FileNameHelper
    {
        static FileNameHelper()
        {
            // TODO: Set the path to the XML files
            // NOTE: Normally, this would be in a configuration file
            Path = "../../../../../Xml/";

            ProductsFile = $"{Path}Products.xml";
            ProductsXsdFile = $"{Path}Products.xsd";
            ProductsAttributesFile = $"{Path}ProductsAttributes.xml";
            SalesOrderHeadersFile = $"{Path}SalesOrderHeaders.xml";
            SalesOrderDetailsFile = $"{Path}SalesOrderDetails.xml";
            SalesAndDetailsFile = $"{Path}SalesAndDetails.xml";
        }
        public static string Path { get; set; }
        public static string ProductsFile { get; set; }
        public static string ProductsXsdFile { get; set; }
        public static string ProductsAttributesFile { get; set; }
        public static string SalesOrderHeadersFile { get; set; }
        public static string SalesOrderDetailsFile { get; set; }
        public static string SalesAndDetailsFile { get; set; }
    }
}
