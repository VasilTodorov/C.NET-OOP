using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1UsrCtrl
{
    /// <summary>
    /// Event object for EventHandler delegate
    /// </summary>
    public class LoginEventArgs : EventArgs
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public LoginEventArgs(string usr, string pwd)
        {
            UserName = usr;
            Password = pwd;
        }
    }
}
