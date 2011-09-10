using System;
using System.Collections;

namespace DoFactory.GangOfFour.Factory.RealWorld
{

	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Note: constructors call Factory Method
			Document[] documents = new Document[2];
			documents[0] = new Resume();
			documents[1] = new Report();

			// Display document pages
			foreach (Document document in documents)
			{
				Console.WriteLine("\n" + document.GetType().Name+ "--");
				foreach (Page page in document.Pages)
				{
					Console.WriteLine(" " + page.GetType().Name);
				}
			}

			// Wait for user
			Console.Read();		
		}
	}

	// "Product"

	abstract class Page
	{
	}

	// "ConcreteProduct"

	class SkillsPage : Page
	{
	}

	// "ConcreteProduct"

	class EducationPage : Page
	{
	}

	// "ConcreteProduct"

	class ExperiencePage : Page
	{
	}

	// "ConcreteProduct"

	class IntroductionPage : Page
	{
	}

	// "ConcreteProduct"

	class ResultsPage : Page
	{
	}

	// "ConcreteProduct"

	class ConclusionPage : Page
	{
	}

	// "ConcreteProduct"

	class SummaryPage : Page
	{
	}

	// "ConcreteProduct"

	class BibliographyPage : Page
	{
	}

	// "Creator"

	abstract class Document
	{
		private ArrayList pages = new ArrayList();

		// Constructor calls abstract Factory method
		public Document()
		{
			this.CreatePages();
		}

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
