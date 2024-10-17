using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    /// <summary>
    /// Represents Login event object
    /// </summary>
    public class LoginEventArgs : EventArgs
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
