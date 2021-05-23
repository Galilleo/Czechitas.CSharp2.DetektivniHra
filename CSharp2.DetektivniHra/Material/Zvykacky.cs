using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra.Material
{
    public class Zvykacky : IDukazniMaterial
    {
        public string Znacka { get; private set; } = "Sharpit (bez cukru)";
        public bool JeProzkoumany { get; set; }
    }
}
