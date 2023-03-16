using XMLSamples;

CachingViewModel vm = new();

Console.WriteLine("Get data");
vm.GetData();

DetectChangesViewModel vm2 = new();

Console.WriteLine("Detect changes");
vm2.CompareData();