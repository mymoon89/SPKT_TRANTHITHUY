using System;

namespace DoFactory.GangOfFour.Prototype.Structural
{
	
	// MainApp startup application

	class MainApp
	{
		
		static void Main()
		{
			// Create two instances and clone each

			ConcretePrototype1 p1 = new ConcretePrototype1("I");
			ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
			Console.WriteLine ("Cloned: {0}", c1.Id);

			ConcretePrototype2 p2 = new ConcretePrototype2("II");
			ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
			Console.WriteLine ("Cloned: {0}", c2.Id);

			// Wait for user
			Console.Read();
		}
	}

	// "Prototype" 

	abstract class Prototype
	{
		private string id;

		// Constructor
		public Prototype(string id)
		{
			this.id = id;
		}

		// Property
		public string Id
		{
			get{ return id; }
		}

		public abstract Prototype Clone();
	}

	// "ConcretePrototype1"

	class ConcretePrototype1 : Prototype
	{
		// Constructor
		public ConcretePrototype1(string id) : base(id) 
		{
		}

		public override Prototype Clone()
		{
			// Shallow copy
			return (Prototype)this.MemberwiseClone();
		}
	}

	// "ConcretePrototype2"

	class ConcretePrototype2 : Prototype
	{
		// Constructor
		public ConcretePrototype2(string id) : base(id) 
		{
		}

		public override Prototype Clone()
		{
			// Shallow copy
			return (Prototype)this.MemberwiseClone();
		}
	}
}
