using System;

namespace Multicast_Delegates
{

	delegate void MyDelegate3(string s);

	class MyClass
	{
		public static void Hello(string s) 
		{
			Console.WriteLine("  Hello, {0}!", s);
		}

		public static void Goodbye(string s) 
		{
			Console.WriteLine("  Goodbye, {0}!", s);
		}

		public static void Main() 
		{
			MyDelegate3 a, b, c, d;
			a = new MyDelegate3(MyClass.Hello);
			b = new MyDelegate3(MyClass.Goodbye);
			c = a + b;   // Compose two delegates to make another
			d = c - a;   // Remove a from c to make another

			Console.WriteLine("Invoking delegate a:");
			a("A");
			Console.WriteLine("Invoking delegate b:");
			b("B");
			Console.WriteLine("Invoking delegate c:");
			c("C");
			Console.WriteLine("Invoking delegate d:");
			d("D");

			Console.WriteLine("Adding b to a and invoking:");
			a += b;		// Add the b delegate to a
			a("E");
			Console.WriteLine("Removing b from a and invoking:");
			a -= b;		// Remove the b delegate from a
			a("F");
		}
	}

}
