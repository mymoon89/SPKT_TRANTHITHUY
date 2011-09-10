using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary; 

namespace DoFactory.GangOfFour.Prototype.NETOptimized
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

			// User uses selected colors
			Color color;

			string name = "red";
			color = colormanager[name].Clone() as Color;

			name = "peace";
			color = colormanager[name].Clone() as Color;

			// Create a "deep copy"
			name = "flame";
			color = colormanager[name].Clone(false) as Color;

			// Wait for user
			Console.Read();
		}
	}

	// "ConcretePrototype"

	[Serializable()]
	class Color : ICloneable
	{
		private byte red;
		private byte green;
		private byte blue;

		// Constructor
		public Color(byte red, byte green, byte blue)
		{
			this.red   = red;
			this.green = green;
			this.blue  = blue;
		}

		// Properties
		public byte Red
		{
			get{ return red; }
		}

		public byte Green
		{
			get{ return green; }
		}

		public byte Blue
		{
			get{ return blue; }
		}

		public object Clone(bool shallow)
		{
			if (shallow)
			{
				return Clone();
			}
			else
			{
				return DeepCopy();
			}
		}

		// Create a shallow copy
		public object Clone()
		{
			Console.WriteLine(
				"Shallow copy of color RGB: {0,3},{1,3},{2,3}", 
				red, green, blue);

			return this.MemberwiseClone();
		}

		// Create a deep copy
		public object DeepCopy()
		{
			MemoryStream stream = new MemoryStream();
			BinaryFormatter formatter = new BinaryFormatter();
  
			formatter.Serialize(stream, this);
			stream.Seek(0, SeekOrigin.Begin);

			object copy = formatter.Deserialize(stream);
			stream.Close();

			Console.WriteLine(
				"*Deep*  copy of color RGB: {0,3},{1,3},{2,3}", 
				(copy as Color).Red, 
				(copy as Color).Green, 
				(copy as Color).Blue);

			return copy;
		}
	}

	// Prototype manager

	class ColorManager
	{
		Hashtable colors = new Hashtable();

		// Indexer
		public Color this[string name]
		{
			get
			{ 
				return colors[name] as Color; 
			}
			set
			{ 
				colors.Add(name, value); 
			}
		}
	}
}
