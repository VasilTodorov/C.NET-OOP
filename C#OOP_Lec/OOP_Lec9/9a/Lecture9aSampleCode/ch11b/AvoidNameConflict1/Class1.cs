using System;

interface ISerializable
{
	void SaveData();
}

interface IDataStore
{
	void SaveData();
}

class Test : ISerializable, IDataStore
{
	public void SaveData() 
	{ 
		Console.WriteLine("Test.SaveData called"); 
	}
}

class NameCollisions2App
{
	public static void Main()
	{
		Test test = new Test();

		Console.WriteLine("Testing to see if Test " +
			"implements ISerializable...");
		Console.WriteLine("ISerializable is {0}implemented\n",
			test is ISerializable ? "" : "NOT ");

		Console.WriteLine("Testing to see if Test " +
			"implements IDataStore...");
		Console.WriteLine("IDataStore is {0}implemented\n",
			test is IDataStore ? "" : "NOT ");
	}
}