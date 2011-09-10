using System;

namespace DoFactory.GangOfFour.Proxy.RealWorld
{
	
	// MainApp startup application

	class MainApp
	{
		static void Main()
		{
			// Create math proxy
			MathProxy p = new MathProxy();

			// Do the math
			Console.WriteLine("4 + 2 = " + p.Add(4, 2));
			Console.WriteLine("4 - 2 = " + p.Sub(4, 2));
			Console.WriteLine("4 * 2 = " + p.Mul(4, 2));
			Console.WriteLine("4 / 2 = " + p.Div(4, 2));

			// Wait for user
			Console.Read();
		}
	}

	// "Subject" 

	public interface IMath
	{
		double Add(double x, double y);
		double Sub(double x, double y);
		double Mul(double x, double y);
		double Div(double x, double y);
	}

	// "RealSubject" 

	class Math : IMath
	{
		public double Add(double x, double y){return x + y;}
		public double Sub(double x, double y){return x - y;}
		public double Mul(double x, double y){return x * y;}
		public double Div(double x, double y){return x / y;}
	}

	// "Proxy Object" 

	class MathProxy : IMath
	{
		Math math;

		public MathProxy()
		{
			math = new Math();
		}

		public double Add(double x, double y)
		{ 
			return math.Add(x,y); 
		}
		public double Sub(double x, double y)
		{ 
			return math.Sub(x,y); 
		}
		public double Mul(double x, double y)
		{ 
			return math.Mul(x,y); 
		}
		public double Div(double x, double y)
		{ 
			return math.Div(x,y); 
		}
	}
}
