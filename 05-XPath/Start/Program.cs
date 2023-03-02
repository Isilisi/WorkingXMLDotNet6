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