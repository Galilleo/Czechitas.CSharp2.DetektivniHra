using CSharp2.DetektivniHra.Material;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra
{
    public static class Park
    {
        public static readonly List<IDukazniMaterial> Material = new List<IDukazniMaterial>()
            {
                new Zvykacky(),
                new Letak(),
                new Hodinky(),
            };
    }
}
