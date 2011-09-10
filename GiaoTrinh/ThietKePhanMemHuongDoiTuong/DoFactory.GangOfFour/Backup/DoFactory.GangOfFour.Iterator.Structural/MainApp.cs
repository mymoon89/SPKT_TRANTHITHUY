using System;
using System.Collections;

namespace DoFactory.GangOfFour.Iterator.Structural
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			ConcreteAggregate a = new ConcreteAggregate();
			a[0] = "Item A";
			a[1] = "Item B";
			a[2] = "Item C";
			a[3] = "Item D";

			// Create Iterator and provide aggregate
			ConcreteIterator i = new ConcreteIterator(a);

			Console.WriteLine("Iterating over collection:");
			
			object item = i.First();
			while (item != null)
			{
				Console.WriteLine(item);
				item = i.Next();
			} 

			// Wait for user
			Console.Read();
		}
	}

	// "Aggregate" 

	abstract class Aggregate
	{
		public abstract Iterator CreateIterator();
	}

	// "ConcreteAggregate" 

	class ConcreteAggregate : Aggregate
	{
		private ArrayList items = new ArrayList();

		public override Iterator CreateIterator()
		{
			return new ConcreteIterator(this);
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
			set{ items.Insert(index, value); }
		}
	}

	// "Iterator"

	abstract class Iterator
	{
		public abstract object First();
		public abstract object Next();
		public abstract bool IsDone();
		public abstract object CurrentItem();
	}

	// "ConcreteIterator" 

	class ConcreteIterator : Iterator
	{
		private ConcreteAggregate aggregate;
		private int current = 0;

		// Constructor
		public ConcreteIterator(ConcreteAggregate aggregate)
		{
			this.aggregate = aggregate;
		}

		public override object First()
		{
			return aggregate[0];
		}

		public override object Next()
		{
			object ret = null;
			if (current < aggregate.Count - 1)
			{
				ret = aggregate[++current];
			}
			
			return ret;
		}

		public override object CurrentItem()
		{
			return aggregate[current];
		}

		public override bool IsDone()
		{
			return current >= aggregate.Count ? true : false ;
		}
	}
}
