using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Patterns.AEP
{
    static class Extension
    {
        public static async Task WhenClicked(this Ellipse ellipse)
        {
            var tcs = new TaskCompletionSource<bool>();
            MouseButtonEventHandler ev = (sender, evt) => tcs.TrySetResult(true);

            try
            {
                ellipse.MouseDown += ev;
                await tcs.Task;
            }
            finally 
            {
                ellipse.MouseDown -= ev;
            }
        }
    }
}
