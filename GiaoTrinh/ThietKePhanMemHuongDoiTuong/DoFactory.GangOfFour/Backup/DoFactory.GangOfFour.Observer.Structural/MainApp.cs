using System;
using System.Collections;

namespace DoFactory.GangOfFour.Observer.Structural
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Configure Observer pattern
			ConcreteSubject s = new ConcreteSubject();

			s.Attach(new ConcreteObserver(s,"X"));
			s.Attach(new ConcreteObserver(s,"Y"));
			s.Attach(new ConcreteObserver(s,"Z"));

			// Change subject and notify observers
			s.SubjectState = "ABC";
			s.Notify();

			// Wait for user
			Console.Read();
		}
	}

	// "Subject" 

	abstract class Subject
	{
		private ArrayList observers = new ArrayList();

		public void Attach(Observer observer)
		{
			observers.Add(observer);
		}

		public void Detach(Observer observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (Observer o in observers)
			{
				o.Update();
			}
		}
	}

	// "ConcreteSubject" 

	class ConcreteSubject : Subject
	{
		private string subjectState;

		// Property
		public string SubjectState
		{
			get{ return subjectState; }
			set{ subjectState = value; }
		}
	}

	// "Observer" 

	abstract class Observer
	{
		public abstract void Update();
	}

	// "ConcreteObserver" 

	class ConcreteObserver : Observer
	{
		private string name;
		private string observerState;
		private ConcreteSubject subject;

		// Constructor
		public ConcreteObserver(
			ConcreteSubject subject, string name)
		{
			this.subject = subject;
			this.name = name;
		}

		public override void Update()
		{
			observerState = subject.SubjectState;
			Console.WriteLine("Observer {0}'s new state is {1}",
				name, observerState);
		}

		// Property
		public ConcreteSubject Subject
		{
			get { return subject; }
			set { subject = value; }
		}
	}
}
