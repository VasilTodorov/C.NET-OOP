// cs_modifier_new.cs
// Ullustrates inheritance and hidding of members
using System;
public class MyBaseC
{
	public static int x = 55;
	public static int y = 22;

	public static  string Invoke() 
	{
		return "Invoke static in base\n";
	}
	public  string Invokes()
	{
		return "Invoke member in base\n";
	}
	public virtual string InvokeWithVirtual()
	{
		return "Invoke member in base\n";
	}
}

public class MyDerivedC : MyBaseC
{
	new public static int x = 100;   // Name hiding
	new public  string Invokes()// hide method Invoke() from the base class
	{
		return "Invoke member in derived class\n";
	}
	public override string InvokeWithVirtual()
	{
		return "Invoke member in derived\n";
	}
	public static void Main()
	{
		MyDerivedC d = new MyDerivedC();
		MyBaseC c= d;
		// polymorphism impossible without virtual
		Console.WriteLine("d.Invokes(): {0}",(d.Invokes()));
		Console.WriteLine("c.Invokes(): {0}",c.Invokes());
		// polymorphism with virtual
		Console.WriteLine("d.InvokeWithVirtual(): {0}",d.InvokeWithVirtual());
		Console.WriteLine("c.InvokeWithVirtual(): {0}",c.InvokeWithVirtual());

		// Display the overlapping value of x:
		// static members are inherited by classes

		Console.WriteLine("MyDerivedC.Invoke(): {0}",MyDerivedC.Invoke());
		Console.WriteLine("MyBaseC.Invoke(): {0}",MyBaseC.Invoke());
		// Access the hidden value of x:
        // Console.WriteLine(d.x); // illegal
        Console.WriteLine("MyDerivedC: {0}",MyDerivedC.x);// hidding x from the base class
		Console.WriteLine("MyBaseC: {0}",MyBaseC.x);//  x from the base class
        // Console.WriteLine(d.x); // illegal
		// Display the unhidden member y:
		Console.WriteLine("MyDerivedC: {0}",MyDerivedC.y);// inherited from the base class
		// or the same
        Console.WriteLine("MyBaseC: {0}",MyBaseC.y);
         // or the same
        Console.WriteLine("MyDerivedC: {0}",y);

		Console.ReadLine();
	}
}
