using System;
using System.Collections;

namespace DoFactory.GangOfFour.Prototype.RealWorld
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			ColorManager colormanager = new ColorManager();

			// Initialize with standard colors
			colormanager["red"  ] = new Color(255,   0,   0);
			colormanager["green"] = new Color(  0, 255,   0);
			colormanager["blue" ] = new Color(  0,   0, 255);

			// User adds personalized colors
			colormanager["angry"] = new Color(255,  54,   0);
			colormanager["peace"] = new Color(128, 211, 128);
			colormanager["flame"] = new Color(211,  34,  20);

			Color color;

			// User uses selected colors
			string name = "red";
			color = colormanager[name].Clone() as Color;

			name = "peace";
			color = colormanager[name].Clone() as Color;

			name = "flame";
			color = colormanager[name].Clone() as Color;

			// Wait for user
			Console.Read();
		}
	}

	// "Prototype"

	abstract class ColorPrototype
	{
		public abstract ColorPrototype Clone();
	}

	// "ConcretePrototype"

	class Color : ColorPrototype
	{
		private int red;
		private int green;
		private int blue;

		// Constructor
		public Color(int red, int green, int blue)
		{
			this.red   = red;
			this.green = green;
			this.blue  = blue;
		}

		// Create a shallow copy
		public override ColorPrototype Clone()
		{
			Console.WriteLine(
				"Cloning color RGB: {0,3},{1,3},{2,3}", 
				red, green, blue);

			return this.MemberwiseClone() as ColorPrototype;
		}
	}

	// Prototype manager

	class ColorManager
	{
		Hashtable colors = new Hashtable();

		// Indexer
		public ColorPrototype this[string name]
		{
			get
			{ 
				return colors[name] as ColorPrototype; 
			}
			set
			{ 
				colors.Add(name, value); 
			}
		}
	}
}
