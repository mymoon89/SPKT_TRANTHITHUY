using System;
using System.Runtime.Remoting;

namespace DoFactory.GangOfFour.Proxy.NETOptimized
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

	class Math : MarshalByRefObject, IMath
	{
		public double Add(double x, double y){return x + y;}
		public double Sub(double x, double y){return x - y;}
		public double Mul(double x, double y){return x * y;}
		public double Div(double x, double y){return x / y;}
	}

	// Remote "Proxy Object" 

	class MathProxy : IMath
	{
		Math math;

		public MathProxy()
		{
			// Create Math instance in a different AppDomain
			AppDomain ad = 
				AppDomain.CreateDomain("MathDomain",null, null);

			ObjectHandle o = ad.CreateInstance(
				"DoFactory.GangOfFour.Proxy.NETOptimized", 
				"DoFactory.GangOfFour.Proxy.NETOptimized.Math");
			math = (Math)o.Unwrap();
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
