using System;
using System.Collections;

namespace DoFactory.GangOfFour.Observer.RealWorld
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

	// "Subject" 

	abstract class Stock
	{
		protected string symbol;
		protected double price;
		private ArrayList investors = new ArrayList();

		// Constructor
		public Stock(string symbol, double price)
		{
			this.symbol = symbol;
			this.price = price;
		}

		public void Attach(Investor investor)
		{
			investors.Add(investor);
		}

		public void Detach(Investor investor)
		{
			investors.Remove(investor);
		}

		public void Notify()
		{
			foreach (Investor investor in investors)
			{
				investor.Update(this);
			}
			Console.WriteLine("");
		}

		// Properties
		public double Price
		{
			get{ return price; }
			set
			{
				price = value;
				Notify(); 
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
		void Update(Stock stock);
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

		public void Update(Stock stock)
		{
			Console.WriteLine("Notified {0} of {1}'s " +
				"change to {2:C}", name, stock.Symbol, stock.Price);
		}

		// Property
		public Stock Stock
		{
			get{ return stock; }
			set{ stock = value; }
		}
	}
}
