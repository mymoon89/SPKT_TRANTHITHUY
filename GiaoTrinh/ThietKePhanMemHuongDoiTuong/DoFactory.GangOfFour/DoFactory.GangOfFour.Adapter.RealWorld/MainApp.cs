using System;

namespace DoFactory.GangOfFour.Adapter.RealWorld
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Non-adapted chemical compound
			Compound stuff = new Compound("Unknown");
			stuff.Display();
			
			// Adapted chemical compounds
			Compound water = new RichCompound("Water");
			water.Display();

			Compound benzene = new RichCompound("Benzene");
			benzene.Display();

			Compound alcohol = new RichCompound("Alcohol");
			alcohol.Display();

			// Wait for user
			Console.Read();
		}
	}

	// "Target"

	class Compound
	{
		protected string name;
		protected float boilingPoint;
		protected float meltingPoint;
		protected double molecularWeight;
		protected string molecularFormula;

		// Constructor
		public Compound(string name)
		{
			this.name = name;
		}

		public virtual void Display()
		{
			Console.WriteLine("\nCompound: {0} ------ ", name);
		}
	}

	// "Adapter"

	class RichCompound : Compound
	{
		private ChemicalDatabank bank;

		// Constructor
		public RichCompound(string name) : base(name)
		{
		}

		public override void Display()
		{
			// Adaptee
			bank = new ChemicalDatabank();
			boilingPoint     = bank.GetCriticalPoint(name, "B");
			meltingPoint     = bank.GetCriticalPoint(name, "M");
			molecularWeight  = bank.GetMolecularWeight(name);
			molecularFormula = bank.GetMolecularStructure(name);

			base.Display();
			Console.WriteLine(" Formula: {0}", molecularFormula);
			Console.WriteLine(" Weight : {0}", molecularWeight);
			Console.WriteLine(" Melting Pt: {0}", meltingPoint);
			Console.WriteLine(" Boiling Pt: {0}", boilingPoint);
		}
	}

	// "Adaptee"

	class ChemicalDatabank
	{
		// The Databank 'legacy API'
		public float GetCriticalPoint(string compound, string point)
		{
			float temperature = 0.0F;

			// Melting Point
			if (point == "M")
			{
				switch (compound.ToLower())
				{
					case "water"   : temperature = 0.0F;    break;
					case "benzene" : temperature = 5.5F;    break;
					case "alcohol" : temperature = -114.1F; break;
				}
			}
			// Boiling Point
			else
			{
				switch (compound.ToLower())
				{
					case "water"   : temperature = 100.0F; break;
					case "benzene" : temperature = 80.1F;  break;
					case "alcohol" : temperature = 78.3F;  break;
				}
			}
			return temperature;
		}

		public string GetMolecularStructure(string compound)
		{
			string structure = "";

			switch (compound.ToLower())
			{
				case "water"   : structure = "H20";    break;
				case "benzene" : structure = "C6H6";   break;
				case "alcohol" : structure = "C2H6O2"; break;
			}
			return structure;
		}

		public double GetMolecularWeight(string compound)
		{
			double weight = 0.0;
			switch (compound.ToLower())
			{
				case "water"   : weight = 18.015;  break;
				case "benzene" : weight = 78.1134; break;
				case "alcohol" : weight = 46.0688; break;
			}
			return weight;
		}
	}
}
