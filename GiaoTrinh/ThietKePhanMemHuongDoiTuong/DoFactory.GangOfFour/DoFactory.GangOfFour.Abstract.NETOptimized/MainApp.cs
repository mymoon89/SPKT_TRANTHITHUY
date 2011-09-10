using System;

namespace DoFactory.GangOfFour.Abstract.NETOptimized
{
	// MainApp startup application

	class MainApp
	{
		public static void Main()
		{
			// Create and run the Africa animal world
			AnimalWorld world = new AnimalWorld(Continent.Africa);
			world.RunFoodChain();

			// Create and run the America animal world
			world = new AnimalWorld(Continent.America);
			world.RunFoodChain();

			// Wait for user input
			Console.Read();
		}
	}

	// "AbstractFactory"

	interface IContinentFactory
	{
		IHerbivore CreateHerbivore();
		ICarnivore CreateCarnivore();
	}

	// "ConcreteFactory1"

	class AfricaFactory : IContinentFactory
	{
		public IHerbivore CreateHerbivore()
		{
			return new Wildebeest();
		}
		public ICarnivore CreateCarnivore()
		{
			return new Lion();
		}
	}

	// "ConcreteFactory2"

	class AmericaFactory : IContinentFactory
	{
		public IHerbivore CreateHerbivore()
		{
			return new Bison();
		}
		public ICarnivore CreateCarnivore()
		{
			return new Wolf();
		}
	}

	// "AbstractProductA"

	interface IHerbivore
	{
	}

	// "AbstractProductB"

	interface ICarnivore
	{
		void Eat(IHerbivore h);
	}

	// "ProductA1"

	class Wildebeest : IHerbivore
	{
	}

	// "ProductB1"

	class Lion : ICarnivore
	{
		public void Eat(IHerbivore h)
		{
			// Eat Wildebeest
			Console.WriteLine(this.GetType().Name + 
				" eats " + h.GetType().Name);
		}
	}

	// "ProductA2"

	class Bison : IHerbivore
	{
	}

	// "ProductB2"

	class Wolf : ICarnivore
	{
		public void Eat(IHerbivore h)
		{
			// Eat Bison
			Console.WriteLine(this.GetType().Name + 
				" eats " + h.GetType().Name);
		}
	}

	// "Client" 

	class AnimalWorld
	{
		private IHerbivore herbivore;
		private ICarnivore carnivore;

		// Constructor
		public AnimalWorld(Continent continent)
		{
			// Get fully qualified factory name
			string name = this.GetType().Namespace + "." + 
				continent.ToString() + "Factory";
			
			// Dynamic factory creation
			IContinentFactory factory = 
				(IContinentFactory)System.Activator.CreateInstance
				(Type.GetType(name));
			carnivore = factory.CreateCarnivore();
			herbivore = factory.CreateHerbivore();
		}

		public void RunFoodChain()
		{
			carnivore.Eat(herbivore);
		}
	}

	// World Continent Enumeration

	public enum Continent
	{
		Africa,
		America,
		Asia,
		Europe,
		Australia
	}
}
