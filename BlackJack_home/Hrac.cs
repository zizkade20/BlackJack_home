using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Hrac
    {
        public string Jmeno;
        public int Penize = 200;
        public bool Win;
        public bool Blackjack;



        internal Hrac() { }
        internal Hrac(string _jmeno)
        {
            this.Jmeno = _jmeno;
        }
        
        

        
    }

}
