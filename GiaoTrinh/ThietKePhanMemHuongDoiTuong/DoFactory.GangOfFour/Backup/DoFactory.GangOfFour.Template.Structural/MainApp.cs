using System;

namespace DoFactory.GangOfFour.Template.Structural
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			AbstractClass c;
			
			c = new ConcreteClassA();
			c.TemplateMethod();

			c = new ConcreteClassB();
			c.TemplateMethod();

			// Wait for user
			Console.Read();
		}
	}

	// "AbstractClass"

	abstract class AbstractClass
	{
		public abstract void PrimitiveOperation1();
		public abstract void PrimitiveOperation2();

		// The "Template method"
		public void TemplateMethod()
		{
			PrimitiveOperation1();
			PrimitiveOperation2();
			Console.WriteLine("");
		}
	}

	// "ConcreteClass"

	class ConcreteClassA : AbstractClass
	{
		public override void PrimitiveOperation1()
		{
			Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
		}
		public override void PrimitiveOperation2()
		{
			Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
		}
	}

	class ConcreteClassB : AbstractClass
	{
		public override void PrimitiveOperation1()
		{
			Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
		}
		public override void PrimitiveOperation2()
		{
			Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
		}
	}
}
