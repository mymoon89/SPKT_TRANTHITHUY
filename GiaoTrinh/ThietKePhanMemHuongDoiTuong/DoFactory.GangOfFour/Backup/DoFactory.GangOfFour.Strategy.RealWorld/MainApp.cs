using System;
using System.Collections;

namespace DoFactory.GangOfFour.Strategy.RealWorld
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Two contexts following different strategies
			SortedList studentRecords = new SortedList();

			studentRecords.Add("Samual");
			studentRecords.Add("Jimmy");
			studentRecords.Add("Sandra");
			studentRecords.Add("Vivek");
			studentRecords.Add("Anna");

			studentRecords.SetSortStrategy(new QuickSort());
			studentRecords.Sort();

			studentRecords.SetSortStrategy(new ShellSort());
			studentRecords.Sort();

			studentRecords.SetSortStrategy(new MergeSort());
			studentRecords.Sort();

			// Wait for user
			Console.Read();
		}
	}

	// "Strategy"

	abstract class SortStrategy
	{
		public abstract void Sort(ArrayList list);
	}

	// "ConcreteStrategy" 

	class QuickSort : SortStrategy
	{
		public override void Sort(ArrayList list)
		{
			list.Sort();  // Default is Quicksort
			Console.WriteLine("QuickSorted list ");
		}
	}

	// "ConcreteStrategy" 

	class ShellSort : SortStrategy
	{
		public override void Sort(ArrayList list)
		{ 
			//list.ShellSort();  not-implemented
			Console.WriteLine("ShellSorted list ");
		}
	}

	// "ConcreteStrategy" 

	class MergeSort : SortStrategy
	{
		public override void Sort(ArrayList list)
		{
			//list.MergeSort(); not-implemented
			Console.WriteLine("MergeSorted list ");
		}
	}

	// "Context" 

	class SortedList
	{
		private ArrayList list = new ArrayList();
		private SortStrategy sortstrategy;

		public void SetSortStrategy(SortStrategy sortstrategy)
		{
			this.sortstrategy = sortstrategy;
		}

		public void Add(string name)
		{
			list.Add(name);
		}

		public void Sort()
		{
			sortstrategy.Sort(list);

			// Display results
			foreach (string name in list)
			{
				Console.WriteLine(" " + name);
			}
			Console.WriteLine();
		}
	}
}
