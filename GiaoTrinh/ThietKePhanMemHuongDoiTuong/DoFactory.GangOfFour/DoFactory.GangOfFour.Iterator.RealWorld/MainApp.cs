using System;
using System.Collections;

namespace DoFactory.GangOfFour.Iterator.RealWorld
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

			for(Item item = iterator.First(); 
				!iterator.IsDone; item = iterator.Next())
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

	// "Aggregate"

	interface IAbstractCollection
	{
		Iterator CreateIterator();
	}

	// "ConcreteAggregate" 

	class Collection : IAbstractCollection
	{
		private ArrayList items = new ArrayList();

		public Iterator CreateIterator()
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

	//  "Iterator" 

	interface IAbstractIterator
	{
		Item First();
		Item Next();
		bool IsDone{ get; }
		Item CurrentItem{ get; }
	}

	// "ConcreteIterator" 

	class Iterator : IAbstractIterator
	{
		private Collection collection;
		private int current = 0;
		private int step = 1;

		// Constructor
		public Iterator(Collection collection)
		{
			this.collection = collection;
		}

		public Item First()
		{
			current = 0;
			return collection[current] as Item;
		}

		public Item Next()
		{
			current += step;
			if (!IsDone)
				return collection[current] as Item;
			else
				return null;
		}

		// Properties
		public int Step
		{
			get{ return step; }
			set{ step = value; }
		}

		public Item CurrentItem
		{
			get
			{
				return collection[current] as Item;
			}
		}

		public bool IsDone
		{
			get
			{
				return current >= collection.Count ? true : false;
			}
		}
	}
}
