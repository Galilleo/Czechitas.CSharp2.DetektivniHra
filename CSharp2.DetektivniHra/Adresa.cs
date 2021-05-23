using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra
{
    public class Adresa : IEquatable<Adresa>
    {
        public string Ulice { get; private set; }
        public int CisloPopisne { get; private set; }
        public string Mesto { get; private set; }
        public int PSC { get; private set; }

        public Adresa(string ulice, int cisloPopisne, string mesto, int psc)
        {
            Ulice = ulice;
            CisloPopisne = cisloPopisne;
            Mesto = mesto;
            PSC = psc;
        }

        public bool Equals(Adresa other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                string.Compare(Ulice, other.Ulice, StringComparison.CurrentCultureIgnoreCase) == 0 &&
                string.Compare(Mesto, other.Mesto, StringComparison.CurrentCultureIgnoreCase) == 0 &&
                CisloPopisne == other.CisloPopisne &&
                PSC == other.PSC;
        }
    }
}
