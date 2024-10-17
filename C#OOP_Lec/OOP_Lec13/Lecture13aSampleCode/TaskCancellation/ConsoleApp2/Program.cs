using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp2
{
    class Program
    {/*
        Once a Task has a Status of “Running”, calling Cancel() on the CancellationTokenSource 
        no longer has an effect on the actual Task, it is up to the Action within the Task 
        to respond to the token’s message. The Task is cancelled while running, but it RanToCompletion
        */
        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Task taskWithToken = new Task(
                () =>
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                }, token
            );
            taskWithToken.Start();
            while (taskWithToken.Status != TaskStatus.Running)
            {
                //Wait until task is running
            }
            tokenSource.Cancel();  //cancel...
            taskWithToken.Wait();  //...and wait for the action within the task to complete
            Console.WriteLine(taskWithToken.Status == TaskStatus.Canceled);
            Console.WriteLine(taskWithToken.Status == TaskStatus.RanToCompletion);
        }

    }
}

