using XMLSamples;

ElementViewModel vm = new();

Console.WriteLine("Get all with XDocument");
vm.GetAllXDocument();

Console.WriteLine("\n\nGet all with XElement");
vm.GetAllXElement();

Console.WriteLine("\n\nGet all with XElements with errors");
try
{
    vm.GetAllWithErrors();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("\n\nGet all with XElement with extension methods");
vm.GetAllUsingExtensionMethod();

Console.WriteLine("\n\nGet a single node");
vm.GetASingleNode();

Console.WriteLine("\n\nGet a collection of nodes");
vm.GetACollectionOfNodes();

Console.WriteLine("\n\nGet last node");
vm.GetLastNode();

Console.WriteLine("\n\nGet first three nodes");
vm.GetFirstThreeNodes();

Console.WriteLine("\n\nXML to Csharp class");
vm.AddToClass();

AttributeViewModel vm2 = new();

Console.WriteLine("\n\nGet all attributes");
vm2.GetAll();

Console.WriteLine("\n\nGet a single node with attributes");
vm2.GetASingleNode();

AggregateViewModel vm3 = new();

Console.WriteLine("\n\nGet count of nodes");
vm3.Count();

Console.WriteLine("\n\nGet the sum of line totals");
vm3.Sum();

Console.WriteLine("\n\nGet the average of line totals");
vm3.Average();

Console.WriteLine("\n\nGet the minimum line total");
vm3.Minimum();

Console.WriteLine("\n\nGet the maximum line total");
vm3.Maximum();