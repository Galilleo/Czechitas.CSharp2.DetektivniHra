using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra.Material
{
    public class Hodinky : IDukazniMaterial
    {
        public string Znacka { get; private set; } = "SharpTime";

        public bool JeProzkoumany { get; set; }
    }
}
