using System;
using System.Data;
using System.Data.OleDb;

namespace DoFactory.GangOfFour.Template.RealWorld
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			DataAccessObject dao;
			
			dao = new Categories();
			dao.Run();

			dao = new Products();
			dao.Run();

			// Wait for user
			Console.Read();
		}
	}

	// "AbstractClass"

	abstract class DataAccessObject
	{
		protected string connectionString;

		protected DataSet dataSet;

		public virtual void Connect()
		{
			// Make sure mdb is on solution root directory
			connectionString = 
				"provider=Microsoft.JET.OLEDB.4.0; " +
				"data source=..\\..\\..\\db1.mdb";
		}

		public abstract void Select();
		public abstract void Process();

		public virtual void Disconnect()
		{
			connectionString = "";
		}

		// The "Template Method" 

		public void Run()
		{
			Connect();
			Select();
			Process();
			Disconnect();
		}
	}

	// "ConcreteClass" 

	class Categories : DataAccessObject
	{
		public override void Select()
		{
			string sql = "select CategoryName from Categories";
			OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
				sql, connectionString);

			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Categories");
		}

		public override void Process()
		{
			Console.WriteLine("Categories ---- ");
			
			DataTable dataTable = dataSet.Tables["Categories"];
			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine(row["CategoryName"]);
			}
			Console.WriteLine();
		}
	}

	class Products : DataAccessObject
	{
		public override void Select()
		{
			string sql = "select ProductName from Products";
			OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
				sql, connectionString);

			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Products");
		}

		public override void Process()
		{
			Console.WriteLine("Products ---- ");
			DataTable dataTable = dataSet.Tables["Products"];
			foreach (DataRow row in dataTable.Rows)
			{
				Console.WriteLine(row["ProductName"]);
			}
			Console.WriteLine();
		}
	}
}
