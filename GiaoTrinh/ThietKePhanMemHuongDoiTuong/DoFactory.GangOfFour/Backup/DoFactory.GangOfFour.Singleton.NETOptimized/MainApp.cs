using System;
using System.Collections;

namespace DoFactory.GangOfFour.Singleton.NETOptimized
{
	
	// MainApp startup application

	class MainApp
	{
		
		static void Main()
		{
			LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
			LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
			LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
			LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

			// Same instance?
			if (b1 == b2 && b2 == b3 && b3 == b4)
			{
				Console.WriteLine("Same instance\n");
			}

			// All are the same instance -- use b1 arbitrarily
			// Load balance 15 requests for a server
			for (int i = 0; i < 15; i++)
			{
				Console.WriteLine(b1.Server);
			}

			// Wait for user
			Console.Read();		
		}
	}
	
	// Singleton

	sealed class LoadBalancer
	{ 
		// Static members are 'eagerly initialized', that is, 
		// immediately when class is loaded for the first time.
		// .NET guarantees thread safety for static initialization
		private static readonly LoadBalancer instance = 
			new LoadBalancer(); 

		private ArrayList servers = new ArrayList();
		private Random random = new Random();

		// Note: constructor is 'private'
		private LoadBalancer() 
		{
			// List of available servers
			servers.Add("ServerI");
			servers.Add("ServerII");
			servers.Add("ServerIII");
			servers.Add("ServerIV");
			servers.Add("ServerV");
		} 

		public static LoadBalancer GetLoadBalancer()
		{
			return instance;
		}
		
		// Simple, but effective load balancer

		public string Server
		{
			get
			{
				int r = random.Next(servers.Count);
				return servers[r].ToString();
			}
		}
	} 
}
