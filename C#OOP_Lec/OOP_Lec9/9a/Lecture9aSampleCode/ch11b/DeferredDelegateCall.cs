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

class DelegateProperty
{
    void printConnections(DBConnection connection)
    {
        Console.WriteLine("[DelegateProperty.printConnections] " +
            "{0}", connection.ConnectionName);
    }
    public DBManager.EnumConnectionsCallback PrintConnections
    {
        get
        {
            return new DBManager.EnumConnectionsCallback(
                printConnections);
        }
    }

    public static void Main()
    {
        DelegateProperty app = new DelegateProperty();
        DBManager dbManager = new DBManager();

        Console.WriteLine("[Main] Calling EnumConnections – " +
            "passing the delegate");
        dbManager.EnumConnections(app.PrintConnections);

        Console.ReadLine();
    }
};