using System;

namespace DoFactory.GangOfFour.Adapter.Structural
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Create adapter and place a request
			Target target = new Adapter();
			target.Request();

			// Wait for user
			Console.Read();
		}
	}

	// "Target" 

	class Target
	{
		public virtual void Request()
		{
			Console.WriteLine("Called Target Request()");
		}
	}

	// "Adapter" 

	class Adapter : Target
	{
		private Adaptee adaptee = new Adaptee();

		public override void Request()
		{
			// Possibly do some other work
			//   and then call SpecificRequest
			adaptee.SpecificRequest();
		}
	}

	// "Adaptee"

	class Adaptee
	{
		public void SpecificRequest()
		{
			Console.WriteLine("Called SpecificRequest()");
		}
	}
}
