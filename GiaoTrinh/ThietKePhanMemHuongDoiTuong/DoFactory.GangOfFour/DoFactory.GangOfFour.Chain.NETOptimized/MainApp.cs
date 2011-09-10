using System;

namespace DoFactory.GangOfFour.Chain.NETOptimized
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Setup Chain of Responsibility
			Director Larry    = new Director();
			VicePresident Sam = new VicePresident();
			President Tammy   = new President();

			Larry.Successor   = Sam;
			Sam.Successor     = Tammy;

			// Generate and process purchase requests
			Purchase p = new Purchase(2034, 350.00, "Supplies");
			Larry.ProcessRequest(p);

			p = new Purchase(2035, 32590.10, "Project X");
			Larry.ProcessRequest(p);

			p = new Purchase(2036, 122100.00, "Project Y");
			Larry.ProcessRequest(p);

			// Wait for user
			Console.Read();
		}
	}

	public class PurchaseEventArgs : EventArgs 
	{
		private int number;
		private double amount;
		private string purpose;

		// Constructor
		public PurchaseEventArgs(int number, double amount, 
			string purpose) 
		{
			this.number = number;
			this.amount = amount;
			this.purpose = purpose;
		}

		// Properties
		public double Amount
		{
			get{ return amount; }
			set{ amount = value; }
		}

		public string Purpose
		{
			get{ return purpose; }
			set{ purpose = value; }
		}

		public int Number
		{
			get{ return number; }
			set{ number = value; }
		}
	}  

	// Delegate type for hooking up purchase requests
	public delegate void PurchaseEventHandler(
	      object sender, PurchaseEventArgs e);

	// "Handler"

	abstract class Approver
	{
		protected Approver successor;

		// Event
		public event PurchaseEventHandler Purchase;

		// Invoke the Purchase event
		public virtual void OnPurchase(PurchaseEventArgs e) 
		{
			if (Purchase != null)
			{
				Purchase(this, e);
			}
		}

		public void ProcessRequest(Purchase purchase)
		{
			OnPurchase(new PurchaseEventArgs(
				purchase.Number, purchase.Amount, purchase.Purpose));
		}

		// Property
		public Approver Successor
		{
			set
			{
				this.successor = value;
			}
		}
	}

	// "ConcreteHandler"

	class Director : Approver
	{
		// Constructor
		public Director()
		{
			// Hook up delegate to event
			this.Purchase += 
				new PurchaseEventHandler(DirectorRequest);
		}

		public void DirectorRequest(object o, PurchaseEventArgs e)
		{
			if (e.Amount < 10000.0)
			{
				Console.WriteLine("{0} approved request# {1}", 
					this.GetType().Name, e.Number);
			}
			else if (successor != null)
			{
				successor.OnPurchase(e);
			}
		}
	}

	// "ConcreteHandler"

	class VicePresident : Approver
	{
		// Constructor
		public VicePresident()
		{
			// Hook up delegate to event
			this.Purchase += 
				new PurchaseEventHandler(VicePresidentRequest);
		}

		public void VicePresidentRequest(object o, 
			PurchaseEventArgs e)
		{
			if (e.Amount < 25000.0)
			{
				Console.WriteLine("{0} approved request# {1}", 
					this.GetType().Name, e.Number);
			}
			else if (successor != null)
			{
				successor.OnPurchase(e);
			}
		}
	}

	// "ConcreteHandler"

	class President : Approver
	{
		// Constructor
		public President()
		{
			// Hook up delegate to event
			this.Purchase += 
				new PurchaseEventHandler(PresidentRequest);
		}

		public void PresidentRequest(object o, PurchaseEventArgs e)
		{
			if (e.Amount < 100000.0)
			{
				Console.WriteLine("{0} approved request# {1}", 
					this.GetType().Name, e.Number);
			}
			else
			{
				Console.WriteLine(
					"Request# {0} requires an executive meeting!", 
					e.Number);
			}
		}
	}

	// Request details

	class Purchase
	{
		private int number;
		private double amount;
		private string purpose;

		// Constructor
		public Purchase(int number, double amount, string purpose)
		{
			this.number = number;
			this.amount = amount;
			this.purpose = purpose;
		}

		// Properties
		public double Amount
		{
			get{ return amount; }
			set{ amount = value; }
		}

		public string Purpose
		{
			get{ return purpose; }
			set{ purpose = value; }
		}

		public int Number
		{
			get{ return number; }
			set{ number = value; }
		}
	}
}
