using System;

namespace NUnit.TestServer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestServerConsoleApp
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{ 
			Console.WriteLine( "Starting Server" );
			string uri = "TestServer";
			if ( args.Length > 0 )
				uri = args[0];

			TestServer server = new TestServer( uri );
			server.Start();

			Console.WriteLine( "Waiting for Stop" );
			server.WaitForStop();

			Console.WriteLine( "Exiting" );
		}
	}
}
