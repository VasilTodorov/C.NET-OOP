using Patterns.AEP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Patterns
{
    /// <summary>
    /// Interaction logic for AsyncEvent.xaml
    /// </summary>
    public partial class AsyncEvent : Window
    {
        const double EW = 28.0;
        const double EH = 28.0;
        const int STARS = 20;

        List<GameEllipse> ellipses;

        public AsyncEvent()
        {
            ellipses = new List<GameEllipse>();

            InitializeComponent();

            CreateEllipses();
            ShuffleEllipses();
        }

        #region Helpers

        void CreateEllipses()
        {
            GameEllipse.SetBoundary(Width, Height);

            for (int i = 0; i < STARS; i++)
            {
                var ellipse = new Ellipse();
                ellipse.Visibility = Visibility.Hidden;
                ellipse.Fill = Brushes.Yellow;
                ellipse.Width = EW;
                ellipse.Height = EH;
                ellipse.Stroke = Brushes.DarkGray;
                ellipse.StrokeThickness = 0.5;
                area.Children.Add(ellipse);
                ellipses.Add(new GameEllipse
                {
                    Shape = ellipse
                });
            }
        }

        void ShuffleEllipses()
        {
            Random r = new Random();

            for (int i = 0; i < ellipses.Count; i++)
            {
                var ellipse = ellipses[i];
                ellipse.X = r.NextDouble() * Width - EW * 0.5;
                ellipse.Y = r.NextDouble() * Height - EH * 0.5;
                ellipse.Vx = r.NextDouble() * 5 - 2.5;
                ellipse.Vy = r.NextDouble() * 5 - 2.5;
                Canvas.SetLeft(ellipse.Shape, ellipse.X);
                Canvas.SetBottom(ellipse.Shape, ellipse.Y);
            }
        }

        void ShowEllipses()
        {
            for (int i = 0; i < ellipses.Count; i++)
                ellipses[i].Shape.Visibility = Visibility.Visible;
        }

        Task MoveEllipses(CancellationTokenSource cancel)
        {
            return new Task(() =>
            {
                while (!cancel.Token.IsCancellationRequested)
                {
                    try
                    {
                        Dispatcher.Invoke(() =>
                        {
                            for (int i = 0; i < ellipses.Count; i++)
                            {
                                var ellipse = ellipses[i];
                                ellipse.UpdatePosition();
                                Canvas.SetLeft(ellipse.Shape, ellipse.X);
                                Canvas.SetBottom(ellipse.Shape, ellipse.Y);
                            }
                        });

                    }catch(TaskCanceledException)
                    {
                        cancel.Cancel();    
                    }
                    Thread.Sleep(10);
                }
            }, cancel.Token);
        }

        #endregion

        async void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            var active = new List<GameEllipse>(ellipses);
            var cts = new CancellationTokenSource();
            startButton.Visibility = Visibility.Hidden;
            ShowEllipses();

            var movingEllipses = MoveEllipses(cts);
            var time = DateTime.Now;
            movingEllipses.Start();

            while (active.Count > 0)
            {
                int index = r.Next(0, active.Count);
                var selected = active[index];
                selected.Shape.Fill = Brushes.Red;
                await selected.Shape.WhenClicked();
                selected.Shape.Fill = Brushes.Yellow;
                selected.Shape.Visibility = System.Windows.Visibility.Hidden;
                active.RemoveAt(index);
            }

            var ts = DateTime.Now.Subtract(time);
            cts.Cancel();
            MessageBox.Show("Your time: " + ts.Seconds + " seconds.");
            startButton.Visibility = Visibility.Visible;
        }
    }
}
