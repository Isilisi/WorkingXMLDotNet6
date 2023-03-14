using XMLSamples;

ElementViewModel vm = new();

Console.WriteLine("Get all documents");
vm.GetAllXDocument();

Console.WriteLine("\n\nGet all elements");
vm.GetAllXElement();

Console.WriteLine("\n\nGet all silver products");
vm.WhereClause();

Console.WriteLine("\n\nGet product by id");
vm.GetASingleNode();

Console.WriteLine("\n\nOrder products by color and price");
vm.OrderBy();

Console.WriteLine("\n\nConvert xml to c# classes");
vm.AddToClass();

Console.WriteLine("\n\nJoin products with orders");
vm.Join();

Console.WriteLine("\n\nGet sales without details");
vm.GetSalesWithDetails();

Console.WriteLine("\n\nSales with line total greater than 5k");
vm.GetSalesLineTotalGreaterThan();

AttributeViewModel vm2 = new();

Console.WriteLine("\n\nGet all with attributes");
vm2.GetAll();

Console.WriteLine("\n\nGet all with attributes with helper method");
vm2.GetAllUsingExtensionMethod();

Console.WriteLine("\n\nGet a single node with attributes");
vm2.GetASingleNode();

Console.WriteLine("\n\nOrder by attribute");
vm2.OrderBy();

AggregateViewModel vm3 = new();

Console.WriteLine("\n\nCount");
vm3.Count();

Console.WriteLine("\n\nSum");
vm3.Sum();

Console.WriteLine("\n\nAverage");
vm3.Average();

Console.WriteLine("\n\nMin");
vm3.Minimum();

Console.WriteLine("\n\nMax");
vm3.Maximum();