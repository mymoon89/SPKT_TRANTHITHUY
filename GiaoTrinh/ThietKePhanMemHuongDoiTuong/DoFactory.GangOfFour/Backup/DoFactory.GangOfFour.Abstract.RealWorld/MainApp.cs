using System;

namespace DoFactory.GangOfFour.Abstract.RealWorld
{
	// MainApp startup application

	class MainApp
	{
		public static void Main()
		{
			// Create and run the Africa animal world
			ContinentFactory africa = new AfricaFactory();
			AnimalWorld world = new AnimalWorld(africa);
			world.RunFoodChain();

			// Create and run the America animal world
			ContinentFactory america = new AmericaFactory();
			world = new AnimalWorld(america);
			world.RunFoodChain();

			// Wait for user input
			Console.Read();
		}
	}

	// "AbstractFactory"

	abstract class ContinentFactory
	{
		public abstract Herbivore CreateHerbivore();
		public abstract Carnivore CreateCarnivore();
	}

	// "ConcreteFactory1"

	class AfricaFactory : ContinentFactory
	{
		public override Herbivore CreateHerbivore()
		{
			return new Wildebeest();
		}
		public override Carnivore CreateCarnivore()
		{
			return new Lion();
		}
	}

	// "ConcreteFactory2"

	class AmericaFactory : ContinentFactory
	{
		public override Herbivore CreateHerbivore()
		{
			return new Bison();
		}
		public override Carnivore CreateCarnivore()
		{
			return new Wolf();
		}
	}

	// "AbstractProductA"

	abstract class Herbivore
	{
	}

	// "AbstractProductB"

	abstract class Carnivore
	{
		public abstract void Eat(Herbivore h);
	}

	// "ProductA1"

	class Wildebeest : Herbivore
	{
	}

	// "ProductB1"

	class Lion : Carnivore
	{
		public override void Eat(Herbivore h)
		{
			// Eat Wildebeest
			Console.WriteLine(this.GetType().Name + 
				" eats " + h.GetType().Name);
		}
	}

	// "ProductA2"

	class Bison : Herbivore
	{
	}

	// "ProductB2"

	class Wolf : Carnivore
	{
		public override void Eat(Herbivore h)
		{
			// Eat Bison
			Console.WriteLine(this.GetType().Name + 
				" eats " + h.GetType().Name);
		}
	}

	// "Client" 

	class AnimalWorld
	{
		private Herbivore herbivore;
		private Carnivore carnivore;

		// Constructor
		public AnimalWorld(ContinentFactory factory)
		{
			carnivore = factory.CreateCarnivore();
			herbivore = factory.CreateHerbivore();
		}

		public void RunFoodChain()
		{
			carnivore.Eat(herbivore);
		}
	}
}