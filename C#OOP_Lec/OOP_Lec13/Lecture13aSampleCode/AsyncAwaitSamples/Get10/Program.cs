using System;
using System.Threading.Tasks;
//Page556
class MyClass
{
   public int Get10() // Func<int> compatible
   {
      return 10;
   }
   public async Task DoWorkAsync()
   {
      Func<int> ten = new Func<int>( Get10 );
      int a = await Task.Run( ten );

      int b = await Task.Run( new Func<int>( Get10 ) );

      int c = await Task.Run( () => { return 10; } );

      Console.WriteLine( "{0} {1} {2}", a, b, c );
   }
}

class Program
{
   static void Main()
   {
      Task t = ( new MyClass() ).DoWorkAsync();
     // if the main thread ends, the Task won't finish 
       t.Wait(); // Wait the Task to end and then exit the main thread
   }
}