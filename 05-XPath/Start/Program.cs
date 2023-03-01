using XMLSamples;

ElementViewModel vm = new();

Console.WriteLine("Get all with XDocument");
vm.GetAllXDocument();


Console.WriteLine("Get all with XElement");
vm.GetAllXElement();

Console.ReadKey();