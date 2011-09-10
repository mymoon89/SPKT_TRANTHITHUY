using System;
using System.Collections;

namespace DoFactory.GangOfFour.Visitor.Structural
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Setup structure
			ObjectStructure o = new ObjectStructure();
			o.Attach(new ConcreteElementA());
			o.Attach(new ConcreteElementB());

			// Create visitor objects
			ConcreteVisitor1 v1 = new ConcreteVisitor1();
			ConcreteVisitor2 v2 = new ConcreteVisitor2();

			// Structure accepting visitors
			o.Accept(v1);
			o.Accept(v2);

			// Wait for user
			Console.Read();
		}
	}

	// "Visitor" 

	abstract class Visitor
	{
		public abstract void VisitConcreteElementA(
			ConcreteElementA concreteElementA);
		public abstract void VisitConcreteElementB(
			ConcreteElementB concreteElementB);
	}

	// "ConcreteVisitor1" 

	class ConcreteVisitor1 : Visitor
	{
		public override void VisitConcreteElementA(
			ConcreteElementA concreteElementA)
		{
			Console.WriteLine("{0} visited by {1}",
				concreteElementA.GetType().Name, this.GetType().Name);
		}

		public override void VisitConcreteElementB(
			ConcreteElementB concreteElementB)
		{
			Console.WriteLine("{0} visited by {1}",
				concreteElementB.GetType().Name, this.GetType().Name);
		}
	}

	// "ConcreteVisitor2" 

	class ConcreteVisitor2 : Visitor
	{
		public override void VisitConcreteElementA(
			ConcreteElementA concreteElementA)
		{
			Console.WriteLine("{0} visited by {1}",
				concreteElementA.GetType().Name, this.GetType().Name);
		}

		public override void VisitConcreteElementB(
			ConcreteElementB concreteElementB)
		{
			Console.WriteLine("{0} visited by {1}",
				concreteElementB.GetType().Name, this.GetType().Name);
		}
	}

	// "Element" 

	abstract class Element
	{
		public abstract void Accept(Visitor visitor);
	}

	// "ConcreteElementA" 

	class ConcreteElementA : Element
	{
		public override void Accept(Visitor visitor)
		{
			visitor.VisitConcreteElementA(this);
		}

		public void OperationA()
		{
		}
	}

	// "ConcreteElementB" 

	class ConcreteElementB : Element
	{
		public override void Accept(Visitor visitor)
		{
			visitor.VisitConcreteElementB(this);
		}

		public void OperationB()
		{
		}
	}

	// "ObjectStructure" 

	class ObjectStructure
	{
		private ArrayList elements = new ArrayList();

		public void Attach(Element element)
		{
			elements.Add(element);
		}

		public void Detach(Element element)
		{
			elements.Remove(element);
		}

		public void Accept(Visitor visitor)
		{
			foreach (Element e in elements)
			{
				e.Accept(visitor);
			}
		}
	}
}
