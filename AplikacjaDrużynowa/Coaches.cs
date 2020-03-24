using System;
using System.Collections.Generic;
using System.Text;

namespace AplikacjaDrużynowa
{
    public class Coaches
    {
        private Coaches wynik2;

        public Coaches(Coaches wynik2)
        {
            this.wynik2 = wynik2;
        }

        public string first_name { get; set; }
        public string last_name { get; set; }

    }
}
