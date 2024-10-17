using System;

public interface IDataBound
{
	void Bind();
}

public class EditBox : IDataBound
{
	// IDataBound implementation
	void IDataBound.Bind()
	{
		Console.WriteLine("Binding to data store...");
	}
}

class NameHiding2App
{
	public static void Main()
	{
		Console.WriteLine();


		EditBox edit = new EditBox();
		Console.WriteLine("Calling EditBox.Bind()...");

		// ERROR: The  following won't compile because
		// the Bind method no longer exists in the 
		// EditBox class's namespace.
		edit.Bind();        

		Console.WriteLine();

		IDataBound bound = (IDataBound)edit;
		Console.WriteLine("Calling (IDataBound)" +
			"EditBox.Bind()...");

		// This is OK because the object was cast to 
		// IDataBound first.
		bound.Bind();    

		Console.ReadLine();
	}
}
