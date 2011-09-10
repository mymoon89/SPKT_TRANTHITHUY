using System;

namespace DoFactory.GangOfFour.Chain.RealWorld
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
			Larry.SetSuccessor(Sam);
			Sam.SetSuccessor(Tammy);

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

	// "Handler"

	abstract class Approver
	{
		protected Approver successor;

		public void SetSuccessor(Approver successor)
		{
			this.successor = successor;
		}

		public abstract void ProcessRequest(Purchase purchase);
	}

	// "ConcreteHandler"

	class Director : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 10000.0)
			{
				Console.WriteLine("{0} approved request# {1}", 
					this.GetType().Name, purchase.Number);
			}
			else if (successor != null)
			{
				successor.ProcessRequest(purchase);
			}
		}
	}

	// "ConcreteHandler"

	class VicePresident : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 25000.0)
			{
				Console.WriteLine("{0} approved request# {1}", 
					this.GetType().Name, purchase.Number);
			}
			else if (successor != null)
			{
				successor.ProcessRequest(purchase);
			}
		}
	}

	// "ConcreteHandler"

	class President : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 100000.0)
			{
				Console.WriteLine("{0} approved request# {1}", 
					this.GetType().Name, purchase.Number);
			}
			else
			{
				Console.WriteLine(
					"Request# {0} requires an executive meeting!", 
					purchase.Number);
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
