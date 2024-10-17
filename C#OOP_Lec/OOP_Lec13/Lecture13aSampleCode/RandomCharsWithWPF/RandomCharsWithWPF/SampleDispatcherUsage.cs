using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfGUIThreads
{
    partial class SampleDispatcherUsage : Window
    {
        //...
        public void SomeMethod(Color bgColor) {
            this.Background = new SolidColorBrush(bgColor);
        }
        void RunsOnWorkerThread()
        {
            Color bgColor = Color.FromRgb(255, 0, 0);
            
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action<Color>(SomeMethod), bgColor);
        }
        //...
    }
}
