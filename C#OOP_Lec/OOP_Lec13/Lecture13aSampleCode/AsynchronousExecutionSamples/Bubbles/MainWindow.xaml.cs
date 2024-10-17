using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Bubbles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GameEllipse> ellipses;
        private Random r = new Random();
        private Stopwatch sw;

        public MainWindow()
        {
            InitializeComponent();
            sw = new Stopwatch();
            ellipses = new List<GameEllipse>();
            GameEllipse.SetBoundary(700, 300);
            for (int i = 0; i < 2; i++)
            {
                Ellipse e = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                };
                 
                GameEllipse ge = new GameEllipse
                {
                    Shape =  e,
                    Vx = 1,
                    Vy = 1,
                    X = r.Next(700),
                    Y = r.Next(300)
                };
                ellipses.Add(ge);
            }

        }
        async void ButtonClicked(object sender, RoutedEventArgs e)
        {
            
            var active = new List<GameEllipse>(ellipses);
            var cts = new CancellationTokenSource();
            startButton.Visibility = Visibility.Hidden;
            ShowEllipses();

            Task movingEllipses = MoveEllipses(cts);
            sw.Start();
            
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

            sw.Stop();
            cts.Cancel();
            MessageBox.Show("Your time: " + (sw.ElapsedMilliseconds/1000) + " seconds.");
            startButton.Visibility = Visibility.Visible;
        }

        private void ShowEllipses()
        {
            foreach (var item in ellipses)
            {
                area.Children.Add(item.Shape);
            }
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

                        Thread.Sleep(10);
                    }
                    catch (TaskCanceledException)
                    {
                        Console.WriteLine("App cancelled...");
                    }
                }
            }, cancel.Token);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);    
        }
    }
}
