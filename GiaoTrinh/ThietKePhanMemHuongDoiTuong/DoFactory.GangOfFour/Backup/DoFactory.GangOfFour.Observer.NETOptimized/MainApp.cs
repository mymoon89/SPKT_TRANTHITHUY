using System;
using System.Collections;

namespace DoFactory.GangOfFour.Observer.NETOptimized
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Create investors
			Investor s = new Investor("Sorros");
			Investor b = new Investor("Berkshire");

			// Create IBM stock and attach investors
			IBM ibm = new IBM("IBM", 120.00);
			ibm.Attach(s);
			ibm.Attach(b);

			// Change price, which notifies investors
			ibm.Price = 120.10;
			ibm.Price = 121.00;
			ibm.Price = 120.50;
			ibm.Price = 120.75;

			// Wait for user
			Console.Read();
		}
	}

	// Delegate type for hooking up stock change requests
	public delegate void ChangeEventHandler(
		object sender, ChangeEventArgs e);

	// Custom event arguments
	public class ChangeEventArgs : EventArgs 
	{
		private string symbol;
		private double price;

		// Constructor
		public ChangeEventArgs(string symbol, double price) 
		{
			this.symbol = symbol;
			this.price = price;
		}

		// Properties
		public double Price
		{
			get{ return price; }
			set{ price = value; }
		}

		public string Symbol
		{
			get{ return symbol; }
			set{ symbol = value; }
		}
	}  

	// "Subject" 

	abstract class Stock
	{
		protected string symbol;
		protected double price;

		// Constructor
		public Stock(string symbol, double price)
		{
			this.symbol = symbol;
			this.price = price;
		}

		// Event
		public event ChangeEventHandler Change;
		
		// Invoke the Change event
		public virtual void OnChange(ChangeEventArgs e) 
		{
			if (Change != null)
			{
				Change(this, e);
			}
		}

		public void Attach(Investor investor)
		{
			Change += new ChangeEventHandler(investor.Update);
		}

		public void Detach(Investor investor)
		{
			Change -= new ChangeEventHandler(investor.Update);
		}

		// Properties
		public double Price
		{
			get{ return price; }
			set
			{
				price = value;
				OnChange(new ChangeEventArgs(symbol,price));
				Console.WriteLine("");
			}
		}

		public string Symbol
		{
			get{ return symbol; }
			set{ symbol = value; }
		}
	}

	// "ConcreteSubject"

	class IBM : Stock
	{
		// Constructor
		public IBM(string symbol, double price)
			: base(symbol, price)
		{
		}
	}

	// "Observer"

	interface IInvestor
	{
		void Update(object sender, ChangeEventArgs e);
	}

	// "ConcreteObserver"

	class Investor : IInvestor
	{
		private string name;
		private Stock stock;

		// Constructor
		public Investor(string name)
		{
			this.name = name;
		}

		public void Update(object sender, ChangeEventArgs e)
		{
			Console.WriteLine("Notified {0} of {1}'s " +
				"change to {2:C}", name, e.Symbol, e.Price);
		}

		// Property
		public Stock Stock
		{
			get{ return stock; }
			set{ stock = value; }
		}
	}
}
