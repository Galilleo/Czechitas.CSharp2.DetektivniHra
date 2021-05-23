using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra.Material
{
    public class VysetrovaciZprava
    {
        public IDukazniMaterial KlicovyDukaz { get; set; }
        public Osoba Pachatel { get; set; }

        public bool JePripadUzavren => Pachatel != null && KlicovyDukaz != null;
    }
}
