using System;

namespace DoFactory.GangOfFour.Facade.Structural
{

	// MainApp startup application

	class MainApp
	{
		public static void Main()
		{
			Facade facade = new Facade();

			facade.MethodA();
			facade.MethodB();

			// Wait for user
			Console.Read();
		}
	}

	// "Subsystem ClassA" 

	class SubSystemOne
	{
		public void MethodOne()
		{
			Console.WriteLine(" SubSystemOne Method");
		}
	}

	// Subsystem ClassB"

	class SubSystemTwo
	{
		public void MethodTwo()
		{
			Console.WriteLine(" SubSystemTwo Method");
		}
	}

	// Subsystem ClassC"

	class SubSystemThree
	{
		public void MethodThree()
		{
			Console.WriteLine(" SubSystemThree Method");
		}
	}

	// Subsystem ClassD"

	class SubSystemFour
	{
		public void MethodFour()
		{
			Console.WriteLine(" SubSystemFour Method");
		}
	}

	// "Facade"

	class Facade
	{
		SubSystemOne one;
		SubSystemTwo two;
		SubSystemThree three;
		SubSystemFour four;

		public Facade()
		{
			one = new SubSystemOne();
			two = new SubSystemTwo();
			three = new SubSystemThree();
			four = new SubSystemFour();
		}

		public void MethodA()
		{
			Console.WriteLine("\nMethodA() ---- ");
			one.MethodOne();
			two.MethodTwo();
			four.MethodFour();
		}

		public void MethodB()
		{
			Console.WriteLine("\nMethodB() ---- ");
			two.MethodTwo();
			three.MethodThree();
		}
	}
}		
