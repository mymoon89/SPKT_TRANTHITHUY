using System;
using System.Collections;
using System.Threading;

namespace DoFactory.GangOfFour.Singleton.RealWorld
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
			// Load balance 15 server requests
			for (int i = 0; i < 15; i++)
			{
				Console.WriteLine(b1.Server);
			}

			// Wait for user
			Console.Read();		
		}
	}

	// "Singleton"

	class LoadBalancer
	{
		private static LoadBalancer instance;
		private ArrayList servers = new ArrayList();

		private Random random = new Random();

		// Lock synchronization object
		private static object syncLock = new object();

		// Constructor (protected)
		protected LoadBalancer() 
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
			// Support multithreaded applications through
			// 'Double checked locking' pattern which (once
			// the instance exists) avoids locking each
			// time the method is invoked
			if (instance == null)
			{
				lock (syncLock)
				{
					if (instance == null)
					{
						instance = new LoadBalancer();
					}
				}
			}
    
			return instance;
		}

		// Simple, but effective random load balancer

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
