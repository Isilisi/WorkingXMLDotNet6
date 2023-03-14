using XMLSamples;

// Create instance of view model
SerializeViewModel vm = new();

Console.WriteLine("Serialize");
vm.SerializeProduct();

Console.WriteLine("\n\nDeserialize");
vm.DeserializeProduct();

FormatViewModel vm2 = new();

Console.WriteLine("\n\nSerialize with formatting");
vm2.SerializeProduct();

Console.WriteLine("\n\nDeserialize with formatting");
vm2.DeserializeProduct();

ExtensionViewModel vm3 = new();

Console.WriteLine("\n\nSerialize via extension method");
vm3.SerializeProduct();

Console.WriteLine("\n\nDeserialize via extension method");
vm3.DeserializeProduct();

AttributesViewModel vm4 = new();

Console.WriteLine("\n\nSerialize with attributes");
vm4.SerializeProduct();

Console.WriteLine("\n\nDeserialize with attributes");
vm4.DeserializeProduct();

NestedViewModel vm5 = new();

Console.WriteLine("\n\nSerialize product nested with sales");
vm5.SerializeProductSales();

Console.WriteLine("\n\nDeserialize product nested with sales");
vm5.DeserializeProductSales();

DataContractViewModel vm6 = new();

Console.WriteLine("\n\nSerialize product with data contract serializer");
vm6.SerializeProduct();

Console.WriteLine("\n\nDeserialize product with data contract serializer");
vm6.DeserializeProduct();

BinaryViewModel vm7 = new();

Console.WriteLine("\n\nSerialize product with binary serializer");
vm7.SerializeProduct();

Console.WriteLine("\n\nDeserialize product with binary serializer");
vm7.DeserializeProduct();