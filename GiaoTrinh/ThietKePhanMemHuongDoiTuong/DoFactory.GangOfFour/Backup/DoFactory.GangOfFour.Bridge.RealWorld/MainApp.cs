using System;
using System.Collections;

namespace DoFactory.GangOfFour.Bridge.RealWorld
{

	// MainApp startup application
	
	class MainApp
	{
		static void Main()
		{
			// Create RefinedAbstraction
			Customers customers = 
				new Customers("Chicago");

			// Set ConcreteImplementor
			customers.Data = new CustomersData();

			// Exercise the bridge
			customers.Show();
			customers.Next();
			customers.Show();
			customers.Next();
			customers.Show();
			customers.New("Henry Velasquez");

			customers.ShowAll();

			// Wait for user
			Console.Read();
		}
	}

	// "Abstraction"

	class CustomersBase
	{
		private DataObject dataObject;
		protected string group;

		public CustomersBase(string group)
		{
			this.group = group;
		}

		// Property
		public DataObject Data
		{
			set{ dataObject = value; }
			get{ return dataObject; }
		}

		public virtual void Next()
		{
			dataObject.NextRecord();
		}

		public virtual void Prior()
		{
			dataObject.PriorRecord();
		}

		public virtual void New(string name)
		{
			dataObject.NewRecord(name);
		}

		public virtual void Delete(string name)
		{
			dataObject.DeleteRecord(name);
		}

		public virtual void Show()
		{
			dataObject.ShowRecord();
		}

		public virtual void ShowAll()
		{
			Console.WriteLine("Customer Group: " + group);
			dataObject.ShowAllRecords();
		}
	}

	// "RefinedAbstraction"

	class Customers : CustomersBase
	{
		// Constructor
		public Customers(string group) : base(group)
		{	
		}

		public override void ShowAll()
		{
			// Add separator lines
			Console.WriteLine();
			Console.WriteLine ("------------------------");
			base.ShowAll();
			Console.WriteLine ("------------------------");
		}
	}

	// "Implementor"

	abstract class DataObject
	{
		public abstract void NextRecord();
		public abstract void PriorRecord();
		public abstract void NewRecord(string name);
		public abstract void DeleteRecord(string name);
		public abstract void ShowRecord();
		public abstract void ShowAllRecords();
	}

	// "ConcreteImplementor" 

	class CustomersData : DataObject
	{
		private ArrayList customers = new ArrayList();
		private int current = 0;

		public CustomersData() 
		{
			// Loaded from a database 
			customers.Add("Jim Jones");
			customers.Add("Samual Jackson");
			customers.Add("Allen Good");
			customers.Add("Ann Stills");
			customers.Add("Lisa Giolani");
		}

		public override void NextRecord()
		{
			if (current <= customers.Count - 1)
			{
				current++;
			}
		}

		public override void PriorRecord()
		{
			if (current > 0)
			{
				current--;
			}
		}

		public override void NewRecord(string name)
		{
			customers.Add(name);
		}

		public override void DeleteRecord(string name)
		{
			customers.Remove(name);
		}

		public override void ShowRecord()
		{
			Console.WriteLine(customers[current]);
		}

		public override void ShowAllRecords()
		{
			foreach (string name in customers)
			{
				Console.WriteLine(" " + name);
			}
		}
	}
}
