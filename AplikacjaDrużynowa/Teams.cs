using System;
using System.Collections.Generic;
using System.Text;

namespace AplikacjaDrużynowa
{
    public class Teams
    {
        private Teams wynik1;

        public Teams(Teams wynik1)
        {
            this.wynik1 = wynik1;
        }

        public int id { get; set; }
        public string school { get; set; }
        public string mascot { get; set; }

    }
}
