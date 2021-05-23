using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra.Studium
{
    public class Kurz
    {
        public string Nazev { get; private set; }
        public TypKurzu Typ { get; private set; }
        public Kurz(string nazev, TypKurzu typ)
        {
            Nazev = nazev;
            Typ = typ;
        }
    }
}
