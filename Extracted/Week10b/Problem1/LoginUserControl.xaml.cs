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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        // pulbish Login event
        public event EventHandler<LoginEventArgs>? Login;

        public LoginUserControl()
        {
            InitializeComponent();
        }

        #region Properties 
        public string UserName
        {
            get
            {
                return TxtUsername.Text;
            }
            set
            {
                TxtUsername.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return TxtPassword.Password;
            }
            set
            {
                TxtPassword.Password = value;
            }
        }

        #endregion

        #region Login event handlers
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Login?.Invoke(this, new LoginEventArgs
            {
                UserName = TxtUsername.Text,
                Password = TxtPassword.Password
            });

        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TxtUsername.Text = string.Empty;
            TxtPassword.Password = string.Empty;

        } 
        #endregion

    }
}
