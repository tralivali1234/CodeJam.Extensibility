namespace CodeJam.Extensibility.Services
{
	[Service(typeof (ISampleService2), typeof (ISampleService3))]
	internal class MultiContractSvc : ISampleService2, ISampleService3
	{
	}
}