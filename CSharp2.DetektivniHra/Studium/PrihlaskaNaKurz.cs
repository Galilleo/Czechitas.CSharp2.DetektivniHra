using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra.Studium
{
    public class PrihlaskaNaKurz
    {
        public Kurz Kurz { get; set; }
        public Osoba Registrovany { get; set; }

        public bool JeSpravneVyplnena => Kurz != null && Registrovany != null;
    }
}
