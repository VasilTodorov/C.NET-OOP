namespace Problem1
{

    /// <summary>
    /// Event subscriber
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            List<Subject> list = new List<Subject>
            {
                new Subject( new int[] {30, 80, 120},"CSharp"),
                new Subject( new int[] {130, 180, 120, 60},"Python"),
            };
            StudentCardReport sc = new StudentCardReport(list);
            sc.Passing += OnPassing!;
            sc.ProcessReport();
        }

        public static void OnPassing(object sender, Subject e)
        {
            var subject =  e as Subject;
            if (subject == null) { return; }
            Console.WriteLine($"Congratulations! Passing subject {subject.Title}. ");
        }
    }
}