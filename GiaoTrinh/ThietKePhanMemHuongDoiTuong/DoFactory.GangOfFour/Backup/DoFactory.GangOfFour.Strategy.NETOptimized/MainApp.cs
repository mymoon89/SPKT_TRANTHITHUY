using System;
using System.Collections;

namespace DoFactory.GangOfFour.Strategy.NETOptimized
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

			studentRecords.SortStrategy = new QuickSort();
			studentRecords.Sort();

			studentRecords.SortStrategy = new ShellSort();
			studentRecords.Sort();

			studentRecords.SortStrategy = new MergeSort();
			studentRecords.Sort();

			// Wait for user
			Console.Read();
		}
	}

	// "Strategy"

	interface ISortStrategy
	{
		void Sort(ArrayList list);
	}

	// "ConcreteStrategy" 

	class QuickSort : ISortStrategy
	{
		public void Sort(ArrayList list)
		{
			list.Sort();  // Default is Quicksort
			Console.WriteLine("QuickSorted list ");
		}
	}

	// "ConcreteStrategy" 

	class ShellSort : ISortStrategy
	{
		public void Sort(ArrayList list)
		{ 
			//list.ShellSort();  not-implemented
			Console.WriteLine("ShellSorted list ");
		}
	}

	// "ConcreteStrategy" 

	class MergeSort : ISortStrategy
	{
		public void Sort(ArrayList list)
		{
			//list.MergeSort(); not-implemented
			Console.WriteLine("MergeSorted list ");
		}
	}

	// "Context" 

	class SortedList
	{
		private ArrayList list = new ArrayList();
		private ISortStrategy sortstrategy;

		// Property
		public ISortStrategy SortStrategy
		{
			set
			{
				this.sortstrategy = value;
			}
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
