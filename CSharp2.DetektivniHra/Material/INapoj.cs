using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.Material
{
    public interface INapoj
    {
        TypNapoje Typ { get; }
        bool JeAlkoholicky { get; }
        byte PocetKostekCukru { get; }

        TajnaPrisada Prisada { get; }
    }
}
