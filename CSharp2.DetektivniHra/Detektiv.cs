using CSharp2.DetektivniHra.Material;
using CSharp2.DetektivniHra.Studium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra
{
    public abstract class Detektiv : Osoba
    {
        public Detektiv(string jmeno) : base(jmeno, Pohlavi.Zenske)
        {
            Dovednost = Dovednost.ReseniProblemu;
            Obleceni = Obleceni.Pyzamo;
        }

        public virtual void ProhledejDukazniMaterial(IReadOnlyList<object> material)
        {

        }

        public virtual void ProhledejBudovu(IReadOnlyList<Mistnost> mistnosti)
        {

        }

        public virtual VysetrovaciZprava OdevzdejVysetrovaciZpravu()
        {
            return null;
        }
    }
}
