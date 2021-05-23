using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2.DetektivniHra
{
    public class Mistnost
    {
        public string Oznaceni { get; private set; }
        public IReadOnlyList<object> Predmety => predmety;

        private List<object> predmety = new List<object>();

        public Mistnost(string oznaceni, List<object> veciVMistnosti)
        {
            Oznaceni = oznaceni;
            predmety = veciVMistnosti;
        }
    }
}
