using System.Collections.ObjectModel;
using System.Net;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeedTheSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DrawSnake snake;
        private bool susspendGame = true;
        DrawFoodFarm foodFarm;
        //Snake snake;
        public MainWindow()
        {
            InitializeComponent();

            snake = new DrawSnake(paintCanvas);
            foodFarm = new DrawFoodFarm(paintCanvas);
            foodFarm.Start();
        }

        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            snake.Length++;
            susspendGame = !susspendGame;
            Point a = new Point(1, 1);
            Point b = new Point(2, 2);
            txtAnswer.Text = "is biting: No , Check: " + a.Distance(b);
        }

        private void paintCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!susspendGame)
            {
                Point destination = e.GetPosition(paintCanvas);
                snake.Move(destination);
                txtAnswer.Text = $"distanse: {snake.TailDis:F6}";
                if (snake.Suspended)
                {
                    susspendGame = true;
                    txtAnswer.Text = $"is biting: Yes + distanseN: {snake.TailDis:F6}";
                }
                else
                {
                    txtAnswer.Text = $"distanse: {snake.TailDis:F6}";
                }
                if (foodFarm.IsNearbyFoodEaten(destination))
                {
                    snake.Length++;
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void paintCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            //snake.DefaultSnake();
            //susspendGame = true;
        }
    }
}