using System;
using System.Collections;

namespace DoFactory.GangOfFour.Iterator.NETOptimized
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Build a collection
			Collection collection = new Collection();
			collection[0] = new Item("Item 0");
			collection[1] = new Item("Item 1");
			collection[2] = new Item("Item 2");
			collection[3] = new Item("Item 3");
			collection[4] = new Item("Item 4");
			collection[5] = new Item("Item 5");
			collection[6] = new Item("Item 6");
			collection[7] = new Item("Item 7");
			collection[8] = new Item("Item 8");

			// Create iterator
			Iterator iterator = new Iterator(collection);
    
			// Skip every other item
			iterator.Step = 2;

			Console.WriteLine("Iterating over collection:");

			while (iterator.MoveNext())
			{
				Item item = iterator.Current as Item;
				Console.WriteLine(item.Name);
			}

			// Alternatively: use .NET foreach syntax

			Console.WriteLine("\nUsing .NET foreach syntax:");
			foreach (Item item in collection)
			{
				Console.WriteLine(item.Name);
			}

			// Wait for user
			Console.Read();
		}
	}

	class Item
	{
		string name;

		// Constructor
		public Item(string name)
		{
			this.name = name;
		}

		// Property
		public string Name
		{
			get{ return name; }
		}
	}

	// "ConcreteAggregate" 

	class Collection : IEnumerable
	{
		private ArrayList items = new ArrayList();

		public IEnumerator GetEnumerator()
		{
			return new Iterator(this);
		}

		// Property
		public int Count
		{
			get{ return items.Count; }
		}
		
		// Indexer
		public object this[int index]
		{
			get{ return items[index]; }
			set{ items.Add(value); }
		}
	}

	// "ConcreteIterator" 

	class Iterator : IEnumerator
	{
		private Collection collection;
		private int current = -1;
		private int step = 1;

		public Iterator(Collection collection)
		{
			this.collection = collection;
		}

		public int Step
		{
			get{ return step; }
			set{ step = value; }
		}

		// Interface implemenations

		public bool MoveNext()
		{
			current += step;
			return current < collection.Count;
		}

		public void Reset()
		{
			current = -1;
		}

		public object Current
		{
			get{ return collection[current]; }
		}
	}
}
