using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problem1UsrCtrl
{
    /// <summary>
    /// Interaction logic for LoginPasswordUserControl.xaml
    /// </summary>
    public partial class LoginPasswordUserControl : UserControl
    {
        /// <summary>
        /// Publish event Login
        /// </summary>
        public event EventHandler<LoginEventArgs>? Login;
        public LoginPasswordUserControl()
        {
            InitializeComponent();

        }

        public string Username
        {
            get { return TxtUserName.Text; }
            set {
                TxtUserName.Text = value; }
            }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
             Login?.Invoke(this, new LoginEventArgs(TxtUserName.Text, TxtPassword.Password));
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TxtPassword.Password = "";
            TxtUserName.Text = "";

        }
    }
    }
