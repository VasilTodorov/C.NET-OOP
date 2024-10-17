using System;
using System.Collections;

class DBConnection
{
	protected static int NextConnectionNbr = 1;

	protected string connectionName;
	public string ConnectionName
	{
		get
		{
			return connectionName;
		}
	}

	public DBConnection()
	{
		connectionName = "Database Connection " 
			+ DBConnection.NextConnectionNbr++;
	}
}

class DBManager
{
	protected ArrayList activeConnections;
	public DBManager()
	{
		activeConnections = new ArrayList();
		for (int i = 1; i < 6; i++)
		{
			activeConnections.Add(new DBConnection());
		}
	}

	public delegate void EnumConnectionsCallback(
		DBConnection connection);
	public void EnumConnections(EnumConnectionsCallback callback)
	{
		foreach (DBConnection connection in activeConnections)
		{
			callback(connection);
		}
	}
};

class InstanceDelegate
{
	public static void PrintConnections(DBConnection connection)
	{
		Console.WriteLine("[InstanceDelegate.PrintConnections] {0}",
			connection.ConnectionName);
	}

	public static void Main()
	{
		DBManager dbManager = new DBManager();

		Console.WriteLine("[Main] Instantiating the " +
			"delegate method");
		DBManager.EnumConnectionsCallback printConnections =
			new DBManager.EnumConnectionsCallback(
			PrintConnections);

		Console.WriteLine("[Main] Calling EnumConnections " +
			"- passing the delegate");
		dbManager.EnumConnections(printConnections);

		Console.ReadLine();
	}
};