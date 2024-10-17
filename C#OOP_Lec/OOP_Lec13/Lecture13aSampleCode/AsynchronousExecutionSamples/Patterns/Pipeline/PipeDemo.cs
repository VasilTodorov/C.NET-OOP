using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.Pipeline
{
    class PipeDemo : IDisposable
    {
        public event EventHandler<LogEventArgs> Log;

        ConcurrentQueue<WorkItem> queue;
        Task queueHandler;
        CancellationTokenSource cancelAll;
        CancellationTokenSource cancelCurrent;
        
        public PipeDemo()
        {
            queue = new ConcurrentQueue<WorkItem>();
        }

        public bool IsProcessing
        {
            get { return cancelCurrent != null; }
        }

        public void Push(WorkItem item)
        {
            queue.Enqueue(item);
            RaiseLog("Item {0} enqueued.", item.Id);

            if (cancelAll == null)
            {
                cancelAll = new CancellationTokenSource();
                queueHandler = QueueHandler();
            }
        }

        public void CancelCurrent()
        {
            if (cancelCurrent == null)
                return;

            cancelCurrent.Cancel();
        }

        public void CancelAll()
        {
            if (cancelAll == null)
                return;

            WorkItem waste;
            cancelAll.Cancel();
            CancelCurrent();

            while (queue.TryDequeue(out waste))
            {
                RaiseLog("Processing element {0} has been skipped.", waste.Id);
            }
        }

        async Task QueueHandler()
        {
            RaiseLog("Kernel started.");

            do
            {
                WorkItem current = null;

                if (!queue.TryDequeue(out current))
                    break;

                cancelCurrent = new CancellationTokenSource();
                RaiseLog("Element {0} has been dequeued. Estimated time is {1}ms.", current.Id, current.WorkTime);

                try
                {
                    //Here we actually call the kernel
                    await Task.Delay(current.WorkTime, cancelCurrent.Token);
                    RaiseLog("Element {0} has been completely processed.", current.Id);
                }
                catch (TaskCanceledException ex)
                {
                    Debug.WriteLine(ex.Message);
                    RaiseLog("Processing element {0} was cancelled.", current.Id);
                }

                cancelCurrent = null;
            }
            while (!cancelAll.IsCancellationRequested);

            cancelAll = null;
            RaiseLog("Kernel stopped.");
        }

        void RaiseLog(string message, params object[] args)
        {
            if (Log != null)
                Log(this, new LogEventArgs(string.Format(message, args)));
        }

        public void Dispose()
        {
            CancelAll();
        }
    }
}
