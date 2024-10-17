using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    public class IntBitProporties
    {
        private int bits;
        public IntBitProporties(int bits) {  
            this.bits = bits; 
        }


        
        public bool this[int index]
        {
            get {
                return (index >=0 && index <=31) && ( bits &  ( 1 << index)) == 0 ? false : true;        
            }
            set { 
              if(index >= 0 && index <= 31)
                {
                    if (value)
                    {

                        bits |= 1 << index;
                    }
                    else  // false- > set bit to 0
                    {
                        bits &= ~(1 << index);
                        // ~(1 << index)
                        // 11111111 01111111 11111111 11111
                        // & bits
                        // 01010100 10010100 01010111 11111
                    }


                }
                
            }

        }

        public override string ToString()
        {
            return bits.ToString();
        }

    }
}
