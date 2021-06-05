using CSharp2.DetektivniHra.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.App
{
    class Caj : INapoj
    {
        public TypNapoje Typ => TypNapoje.Caj;

        public bool JeAlkoholicky => false;

        public byte PocetKostekCukru => 1;

        public TajnaPrisada Prisada => TajnaPrisada.Nic;
    }
}
