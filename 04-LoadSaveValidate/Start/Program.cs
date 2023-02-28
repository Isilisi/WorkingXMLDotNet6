using XMLSamples;

LoadingViewModel vm = new();

Console.WriteLine("Load using XDocument");
vm.LoadUsingXDocument();

Console.WriteLine("\n\nLoad using XElement");
vm.LoadUsingXElement();

Console.WriteLine("\n\nGet first node using XDocument");
vm.GetFirstNodeUsingXDocument();

Console.WriteLine("\n\nGet first node using XElement");
vm.GetFirstNodeUsingXElement();

SaveViewModel vm2 = new();

Console.WriteLine("\n\nSave using XDocument");
vm2.SaveUsingXDocument();

Console.WriteLine("\n\nSave using XmlWriter");
vm2.SaveUsingXmlWriter();

Console.WriteLine("\n\nSave using XmlWriter with formatting");
vm2.XmlWriterFormattingSave();

Console.WriteLine("\n\nSave using DataSet");
vm2.DataSetSave();

ValidateViewModel vm3 = new();

Console.WriteLine("\n\nValidate xml");
vm3.ValidateXml();

Console.WriteLine("\n\nValidate xml with error");
vm3.ValidateXmlWithError();