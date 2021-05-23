using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.Material
{
    public class Doklady : IDukazniMaterial
    {
        public bool JeProzkoumany { get; set; }
        public Osoba Vlastnik => new Osoba("Lektor Zvonimir", Pohlavi.Muzske, Obleceni.UborProLektory, jeZivy: false) { Dovednost = Dovednost.Vyuka, };
    }
}
