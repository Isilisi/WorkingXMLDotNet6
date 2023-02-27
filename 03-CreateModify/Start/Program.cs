using XMLSamples;

var vm = new CreateViewModel();

Console.WriteLine("Empty Document");
vm.CreateEmptyDocument();

Console.WriteLine("\n\nProduct Document");
vm.CreateProductDocument();

Console.WriteLine("\n\nProduct Document with id as attribute");
vm.CreateProductDocumentWithAttributes();

Console.WriteLine("\n\nNested Document");
vm.CreateNestedXmlDocument();

Console.WriteLine("\n\nParsed Document");
vm.ParseStringIntoXDocument();

Console.WriteLine("\n\nParsed Element");
vm.ParseStringIntoXElement();

var vm2 = new AddEditDeleteViewModel();

Console.WriteLine("\n\nAdding new node");
vm2.AddNewNode();

Console.WriteLine("\n\nUpdated node");
vm2.UpdateNode();

Console.WriteLine("\n\nDeleted node");
vm2.DeleteNode();