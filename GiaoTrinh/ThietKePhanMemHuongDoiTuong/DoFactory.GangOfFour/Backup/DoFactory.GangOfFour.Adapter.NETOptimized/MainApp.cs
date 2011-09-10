using System;

namespace DoFactory.GangOfFour.Adapter.NETOptimized
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Non-adapted chemical compound
			Compound stuff = new Compound(Chemical.Unknown);
			stuff.Display();

			// Adapted chemical compounds
			Compound water = new RichCompound(Chemical.Water);
			water.Display();

			Compound benzene = new RichCompound(Chemical.Benzene);
			benzene.Display();

			Compound alcohol = new RichCompound(Chemical.Alcohol);
			alcohol.Display();

			// Wait for user
			Console.Read();
		}
	}

	// "Target"

	class Compound
	{
		private Chemical name;
		private float boilingPoint;
		private float meltingPoint;
		private double molecularWeight;
		private string molecularFormula;

		// Constructor
		public Compound(Chemical name)
		{
			this.name = name;
		}

		public virtual void Display()
		{
			Console.WriteLine("\nCompound: {0} -- ", Name);
		}

		// Properties
		public Chemical Name
		{
			get{ return name; }
		}

		public float BoilingPoint
		{
			get{ return boilingPoint; }
			set{ boilingPoint = value; }
		}

		public float MeltingPoint
		{
			get{ return meltingPoint; }
			set{ meltingPoint = value; }
		}

		public double MolecularWeight
		{
			get{ return molecularWeight; }
			set{ molecularWeight = value; }
		}

		public string MolecularFormula
		{
			get{ return molecularFormula; }
			set{ molecularFormula = value; }
		}
	}

	// "Adapter"

	class RichCompound : Compound
	{
		private ChemicalDatabank bank;

		// Constructor
		public RichCompound(Chemical name) : base(name)
		{	
		}

		public override void Display()
		{
			// Adaptee
			bank = new ChemicalDatabank();

			// Adaptee request methods
			BoilingPoint = bank.GetCriticalPoint(Name, State.Boiling);
			MeltingPoint = bank.GetCriticalPoint(Name, State.Melting);
			MolecularWeight  = bank.GetMolecularWeight(Name);
			MolecularFormula = bank.GetMolecularStructure(Name);

			base.Display();
			Console.WriteLine(" Formula: {0}", MolecularFormula);
			Console.WriteLine(" Weight : {0}", MolecularWeight);
			Console.WriteLine(" Melting Pt: {0}", MeltingPoint);
			Console.WriteLine(" Boiling Pt: {0}", BoilingPoint);
		}
	}

	// "Adaptee"

	class ChemicalDatabank
	{
		// The Databank 'legacy API'
		public float GetCriticalPoint(
					Chemical compound, State point)
		{
			float temperature = 0.0F;

			// Melting Point
			if (point == State.Melting)
			{
				switch (compound)
				{
					case Chemical.Water   : temperature = 0.0F;    break;
					case Chemical.Benzene : temperature = 5.5F;    break;
					case Chemical.Alcohol : temperature = -114.1F; break;
				}
			}
				// Boiling Point
			else if (point == State.Boiling)
			{
				switch (compound)
				{
					case Chemical.Water   : temperature = 100.0F; break;
					case Chemical.Benzene : temperature = 80.1F;  break;
					case Chemical.Alcohol : temperature = 78.3F;  break;
				}
			}
			return temperature;
		}

		public string GetMolecularStructure(Chemical compound)
		{
			string structure = "";

			switch (compound)
			{
				case Chemical.Water   : structure = "H20";    break;
				case Chemical.Benzene : structure = "C6H6";   break;
				case Chemical.Alcohol : structure = "C2H6O2"; break;
			}
			return structure;
		}

		public double GetMolecularWeight(Chemical compound)
		{
			double weight = 0.0;
			switch (compound)
			{
				case Chemical.Water   : weight = 18.015;  break;
				case Chemical.Benzene : weight = 78.1134; break;
				case Chemical.Alcohol : weight = 46.0688; break;
			}
			return weight;
		}
	}

	// Enumerations

	public enum Chemical
	{
		Unknown,
		Water,
		Benzene,
		Alcohol
	}

	public enum State
	{
		Boiling,
		Melting
	}
}
