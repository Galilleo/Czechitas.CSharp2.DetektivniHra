using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra.Material
{
    public class Letak : IDukazniMaterial
    {
        public string Obsah { get; private set; } = "Nabidka kurzu od Rozvoje";
        public bool JeProzkoumany { get; set; }
    }
}
