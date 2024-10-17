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
	void IDataStore.SaveData() 
	{ 
		Console.WriteLine("[Test.SaveData] IDataStore " +
			"implementation called");
	}

	void ISerializable.SaveData() 
	{ 
		Console.WriteLine("[Test.SaveData] ISerializable " +
			"implementation called"); 
	}
}

class NameCollisions3App
{
	public static void Main()
	{
		Test test = new Test();

		Console.WriteLine("[Main] " +
			"Testing to see if Test implements " +
			"ISerializable...");
		Console.WriteLine("[Main] " +
			"ISerializable is {0}implemented",
			test is ISerializable ? "" : "NOT ");
		((ISerializable)test).SaveData();

		Console.WriteLine();

		Console.WriteLine("[Main] " +
			"Testing to see if Test implements " +            "IDataStore...");
		Console.WriteLine("[Main] " +
			"IDataStore is {0}implemented",
			test is IDataStore ? "" : "NOT ");
		((IDataStore)test).SaveData();
	}
}
