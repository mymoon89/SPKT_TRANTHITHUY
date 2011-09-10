using System;
using System.Collections;

namespace DoFactory.GangOfFour.Visitor.RealWorld
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

	interface IVisitor
	{
		void Visit(Element element);
	}

	// "ConcreteVisitor1"

	class IncomeVisitor : IVisitor
	{
		public void Visit(Element element)
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

	class VacationVisitor : IVisitor
	{
		public void Visit(Element element)
		{
			Employee employee = element as Employee;
			
			// Provide 3 extra vacation days
			Console.WriteLine("{0} {1}'s new vacation days: {2}", 
				employee.GetType().Name, employee.Name, 
				employee.VacationDays);
		}
	}

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

	// "Element" 

	abstract class Element
	{
		public abstract void Accept(IVisitor visitor);
	}

	// "ConcreteElement"

	class Employee : Element
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

		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
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

		public void Accept(IVisitor visitor)
		{
			foreach (Employee e in employees)
			{
				e.Accept(visitor);
			}
			Console.WriteLine();
		}
	}
}
