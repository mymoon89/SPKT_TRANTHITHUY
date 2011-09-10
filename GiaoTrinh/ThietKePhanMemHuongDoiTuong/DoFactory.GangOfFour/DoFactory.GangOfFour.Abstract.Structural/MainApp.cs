using System;

namespace DoFactory.GangOfFour.Abstract.Structural
{
	// MainApp startup application

	class MainApp
	{
		public static void Main()
		{
			// Abstract factory #1
			AbstractFactory factory1 = new ConcreteFactory1();
			Client c1 = new Client(factory1);
			c1.Run();

			// Abstract factory #2
			AbstractFactory factory2 = new ConcreteFactory2();
			Client c2 = new Client(factory2);
			c2.Run();

			// Wait for user input
			Console.Read();
		}
	}

	// "AbstractFactory"

	abstract class AbstractFactory
	{
		public abstract AbstractProductA CreateProductA();
		public abstract AbstractProductB CreateProductB();
	}

	// "ConcreteFactory1"

	class ConcreteFactory1 : AbstractFactory
	{
		public override AbstractProductA CreateProductA()
		{
			return new ProductA1();
		}
		public override AbstractProductB CreateProductB()
		{
			return new ProductB1();
		}
	}

	// "ConcreteFactory2"

	class ConcreteFactory2 : AbstractFactory
	{
		public override AbstractProductA CreateProductA()
		{
			return new ProductA2();
		}
		public override AbstractProductB CreateProductB()
		{
			return new ProductB2();
		}
	}

	// "AbstractProductA"

	abstract class AbstractProductA
	{
	}

	// "AbstractProductB"

	abstract class AbstractProductB
	{
		public abstract void Interact(AbstractProductA a);
	}

	// "ProductA1"

	class ProductA1 : AbstractProductA
	{
	}

	// "ProductB1"

	class ProductB1 : AbstractProductB
	{
		public override void Interact(AbstractProductA a)
		{
			Console.WriteLine(this.GetType().Name + 
				" interacts with " + a.GetType().Name);
		}
	}

	// "ProductA2"

	class ProductA2 : AbstractProductA
	{
	}

	// "ProductB2"

	class ProductB2 : AbstractProductB
	{
		public override void Interact(AbstractProductA a)
		{
			Console.WriteLine(this.GetType().Name + 
				" interacts with " + a.GetType().Name);
		}
	}

	// "Client" - the interaction environment of the products

	class Client
	{
		private AbstractProductA AbstractProductA;
		private AbstractProductB AbstractProductB;

		// Constructor
		public Client(AbstractFactory factory)
		{
			AbstractProductB = factory.CreateProductB();
			AbstractProductA = factory.CreateProductA();
		}
  
		public void Run()
		{
			AbstractProductB.Interact(AbstractProductA);
		}
	}
}

