using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class AlarmEventArgs :EventArgs
    {

		private int nrings;
        public AlarmEventArgs(int nrings)
        {
                NRings = nrings;
        }
        public AlarmEventArgs():this(0)
        {
                
        }
        public int NRings
		{
			get { return nrings; }
			set { nrings = value>=0?value:0; }
		}

	}
}
