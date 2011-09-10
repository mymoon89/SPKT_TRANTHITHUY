using System;

namespace DoFactory.GangOfFour.Memento.Structural
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			Originator o = new Originator();
			o.State = "On";

			// Store internal state
			Caretaker c = new Caretaker();
			c.Memento = o.CreateMemento();

			// Continue changing originator
			o.State = "Off";

			// Restore saved state
			o.SetMemento(c.Memento);

			// Wait for user
			Console.Read();
		}
	}

	// "Originator" 

	class Originator
	{
		private string state;

		// Property
		public string State
		{
			get{ return state; }
			set
			{ 
				state = value; 
				Console.WriteLine("State = " + state);
			}
		}

		public Memento CreateMemento()
		{
			return (new Memento(state));
		}

		public void SetMemento(Memento memento)
		{
			Console.WriteLine("Restoring state:");
			State = memento.State;
		}
	}

	// "Memento"

	class Memento
	{
		private string state;

		// Constructor
		public Memento(string state)
		{
			this.state = state;
		}

		// Property
		public string State
		{
			get{ return state; }
		}
	}

	// "Caretaker" 

	class Caretaker
	{
		private Memento memento;

		// Property
		public Memento Memento
		{
			set{ memento = value; }
			get{ return memento; }
		}
	}
}
