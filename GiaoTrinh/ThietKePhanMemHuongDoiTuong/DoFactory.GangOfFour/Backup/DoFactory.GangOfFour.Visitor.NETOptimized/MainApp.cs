using System;
using System.Collections;
using System.Reflection;

namespace DoFactory.GangOfFour.Visitor.NETOptimized
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Setup employee collection
			Employees e = new Employees();
			e.Attach(new Clerk());
			e.Attach(new Director());
			e.Attach(new President());

			// Employees are 'visited'
			e.Accept(new IncomeVisitor());
			e.Accept(new VacationVisitor());

			// Wait for user
			Console.Read();
		}
	}

	// "Visitor"

	public abstract class Visitor 
	{
		// Use reflection to see if the Visitor has a method 
		// named Visit with the appropriate parameter type 
		// (i.e. a specific Employee). If so, invoke it.
		public void ReflectiveVisit(IElement element)
		{
			Type[] types = new Type[] { element.GetType() };
			MethodInfo mi = this.GetType().GetMethod("Visit", types);

			if (mi != null)
			{
				mi.Invoke(this, new object[] { element });
			}
		}
	}

	// "ConcreteVisitor1"

	class IncomeVisitor : Visitor
	{
		// Visit clerk
		public void Visit(Clerk clerk)
		{
			DoVisit(clerk);
		}

		// Visit director
		public void Visit(Director director)
		{
			DoVisit(director);
		}

		private void DoVisit(IElement element)
		{
			Employee employee = element as Employee;
    
			// Provide 10% pay raise
			employee.Income *= 1.10;
			Console.WriteLine("{0} {1}'s new income: {2:C}", 
				employee.GetType().Name, employee.Name, 
				employee.Income);
		}
	}

	// "ConcreteVisitor2"

	class VacationVisitor : Visitor
	{
		// Visit director
		public void Visit(Director director)
		{
			DoVisit(director);
		}

		private void DoVisit(IElement element)
		{
			Employee employee = element as Employee;
			
			// Provide 3 extra vacation days
			employee.VacationDays += 3;
			Console.WriteLine("{0} {1}'s new vacation days: {2}", 
				employee.GetType().Name, employee.Name, 
				employee.VacationDays);
		}
	}

	// "Element" 

	public interface IElement
	{
		void Accept(Visitor visitor);
	}

	// "ConcreteElement"

	class Employee : IElement
	{
		string name;
		double income;
		int vacationDays;

		// Constructor
		public Employee(string name, double income, 
			int vacationDays)
		{
			this.name = name;
			this.income = income;
			this.vacationDays = vacationDays;
		}

		// Properties
		public string Name
		{
			get{ return name; }
			set{ name = value; }
		}

		public double Income
		{
			get{ return income; }
			set{ income = value; }
		}

		public int VacationDays
		{
			get{ return vacationDays; }
			set{ vacationDays = value; }
		}

		public virtual void Accept(Visitor visitor)
		{
			visitor.ReflectiveVisit(this);
		}
	}

	// Three employee 'types'

	class Clerk : Employee
	{
		// Constructor
		public Clerk() : base("Hank", 25000.0, 14)
		{ 
		}
	}

	class Director : Employee
	{
		// Constructor
		public Director() : base("Elly", 35000.0, 16)
		{	
		}
	}

	class President : Employee
	{
		// Constructor
		public President() : base("Dick", 45000.0, 21)
		{	
		}
	}

	// "ObjectStructure"

	class Employees
	{
		private ArrayList employees = new ArrayList();

		public void Attach(Employee employee)
		{
			employees.Add(employee);
		}

		public void Detach(Employee employee)
		{
			employees.Remove(employee);
		}

		public void Accept(Visitor visitor)
		{
			foreach (Employee e in employees)
			{
				e.Accept(visitor);
			}
			Console.WriteLine();
		}
	}
}
