using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    internal class Karta
    {
        internal string Hodnota;
        internal string Barva;


        internal Karta(string _hodnota, string _barva)
        {
            this.Hodnota = _hodnota;
            this.Barva = _barva;
        }

        // funkce zajišťující vzhled zobrazených karet
        internal string VratNazevKarty()
        {
            return Hodnota + Barva;
        }



    }
}

