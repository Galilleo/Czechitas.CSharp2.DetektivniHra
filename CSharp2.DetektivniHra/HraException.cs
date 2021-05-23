using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra
{
    public class HraException : Exception
    {
        public HraException(string message) : base(message)
        {

        }
    }
}
