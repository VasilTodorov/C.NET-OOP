using System;
using System.Windows.Input;

namespace Patterns.AMB
{
    public class FetchCommand : ICommand
    {
        AsyncViewModel vm;

        internal FetchCommand(AsyncViewModel vm)
        {
            this.vm = vm;
        }

        internal void Invalidate()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return !vm.Fetching;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            vm.DoFetch();
        }
    }
}
