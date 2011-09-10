using System;

namespace DoFactory.GangOfFour.State.Structural
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Setup context in a state
			Context c = new Context(new ConcreteStateA());

			// Issue requests, which toggles state
			c.Request();
			c.Request();
			c.Request();
			c.Request();

			// Wait for user
			Console.Read();
		}
	}

	// "State" 

	abstract class State
	{
		public abstract void Handle(Context context);
	}

	// "ConcreteStateA"

	class ConcreteStateA : State
	{
		public override void Handle(Context context)
		{
			context.State = new ConcreteStateB();
		}
	}

	// "ConcreteStateB" 

	class ConcreteStateB : State
	{
		public override void Handle(Context context)
		{
			context.State = new ConcreteStateA();
		}
	}

	// "Context" 

	class Context
	{
		private State state;

		// Constructor
		public Context(State state)
		{
			this.State = state;
		}

		// Property
		public State State
		{
			get{ return state; }
			set
			{ 
				state = value; 
				Console.WriteLine("State: " + 
					state.GetType().Name);
			}
		}

		public void Request()
		{
			state.Handle(this);
		}
	}
}
