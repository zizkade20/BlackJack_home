using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Hrac
    {
        public string Jmeno { get; set; }
        public int Penize { get; set; }
        

        internal Hrac() { }
        internal Hrac(string _jmeno)
        {
            this.Jmeno = _jmeno;
            Penize = 200;
        }
        
        

        
    }

}
