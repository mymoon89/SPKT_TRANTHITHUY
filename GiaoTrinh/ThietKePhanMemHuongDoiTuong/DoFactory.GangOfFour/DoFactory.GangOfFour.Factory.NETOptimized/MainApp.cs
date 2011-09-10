using System;
using System.Collections;

namespace DoFactory.GangOfFour.Factory.NETOptimized
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Note: constructors call Factory Method
			Document[] documents = { new Resume(), new Report() };

			// Display document pages
			foreach (Document document in documents)
			{
				Console.WriteLine(
					"\n" + document.GetType().Name + "--");
				foreach (IPage page in document.Pages)
				{
					Console.WriteLine(" " + page.GetType().Name);
				}
			}

			// Wait for user
			Console.Read();		
		}
	}

	// "Product"

	interface IPage
	{
	}

	// "ConcreteProduct"

	class SkillsPage : IPage
	{
	}

	// "ConcreteProduct"

	class EducationPage : IPage
	{
	}

	// "ConcreteProduct"

	class ExperiencePage : IPage
	{
	}

	// "ConcreteProduct"

	class IntroductionPage : IPage
	{
	}

	// "ConcreteProduct"

	class ResultsPage : IPage
	{
	}

	// "ConcreteProduct"

	class ConclusionPage : IPage
	{
	}

	// "ConcreteProduct"

	class SummaryPage : IPage
	{
	}

	// "ConcreteProduct"

	class BibliographyPage : IPage
	{
	}

	// "Creator"

	abstract class Document
	{
		private ArrayList pages = new ArrayList();

		// Constructor invokes Factory Method
		public Document()
		{
			this.CreatePages();
		}

		// Property
		public ArrayList Pages
		{
			get{ return pages; }
		}

		// Factory Method
		public abstract void CreatePages();
	}

	// "ConcreteCreator"

	class Resume : Document
	{
		// Factory Method implementation
		public override void CreatePages()
		{
			Pages.Add(new SkillsPage());
			Pages.Add(new EducationPage());
			Pages.Add(new ExperiencePage());
		}
	}

	// "ConcreteCreator"

	class Report : Document
	{
		// Factory Method implementation
		public override void CreatePages()
		{
			Pages.Add(new IntroductionPage());
			Pages.Add(new ResultsPage());
			Pages.Add(new ConclusionPage());
			Pages.Add(new SummaryPage());
			Pages.Add(new BibliographyPage());
		}
	}
}
