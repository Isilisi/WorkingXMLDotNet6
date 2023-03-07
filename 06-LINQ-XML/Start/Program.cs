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