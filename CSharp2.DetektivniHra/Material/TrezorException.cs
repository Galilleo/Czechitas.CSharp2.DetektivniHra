using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.Material
{
    public class TrezorException : HraException
    {
        public TrezorException(string message) : base(message)
        {

        }
    }
}
