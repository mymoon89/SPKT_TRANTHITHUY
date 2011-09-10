using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace DoFactory.GangOfFour.Memento.NETOptimized
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			SalesProspect s = new SalesProspect();
			s.Name   = "Joel van Halen";
			s.Phone  = "(412) 256-0990";
			s.Budget = 25000.0;

			// Store internal state
			ProspectMemory m = new ProspectMemory();
			m.Memento = s.SaveMemento();

			// Continue changing originator
			s.Name   = "Leo Welch";
			s.Phone  = "(310) 209-7111";
			s.Budget = 1000000.0;

			// Restore saved state
			s.RestoreMemento(m.Memento);

			// Wait for user
			Console.Read();
		}
	}

	// "Originator" 

	[Serializable()]
	class SalesProspect
	{
		private string name;
		private string phone;
		private double budget;

		// Properties
		public string Name
		{
			get{ return name; }
			set
			{ 
				name = value; 
				Console.WriteLine("Name:   " + name);
			}
		}

		public string Phone
		{
			get{ return phone; }
			set
			{ 
				phone = value; 
				Console.WriteLine("Phone:  " + phone);
			}
		}

		public double Budget
		{
			get{ return budget; }
			set
			{ 
				budget = value; 
				Console.WriteLine("Budget: " + budget);
			}
		}

		public Memento SaveMemento()
		{ 
			Console.WriteLine("\nSaving state --\n");

			Memento memento = new Memento();
			return memento.Serialize(this);
		}

		public void RestoreMemento(Memento memento)
		{
			Console.WriteLine("\nRestoring state --\n");

			SalesProspect s = (SalesProspect)memento.Deserialize();
			this.Name   = s.Name;
			this.Phone  = s.Phone;
			this.Budget = s.Budget;
		}
	}

	// "Memento"

	class Memento
	{
		private MemoryStream stream = new MemoryStream();
		private SoapFormatter formatter = new SoapFormatter();

		public Memento Serialize(object o)
		{
			formatter.Serialize(stream, o);
			return this;
		}

		public object Deserialize()
		{
			stream.Seek(0, SeekOrigin.Begin);
			object o = formatter.Deserialize(stream);
			stream.Close();

			return o;
		}
	}

	// "Caretaker"

	class ProspectMemory
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
