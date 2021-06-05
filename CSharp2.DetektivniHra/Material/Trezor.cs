using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSharp2.DetektivniHra.Material
{
    public class Trezor
    {
        private int pin1;
        private int pin2;
        private int pin3;
        private int pin4;

        public bool JeZamceny { get; private set; }
        
        List<object> obsahTrezoru = new List<object>();

        public Trezor(int pin1, int pin2, int pin3, int pin4, List<object> pocatecniObsah)
        {
            this.pin1 = pin1;
            this.pin2 = pin2;
            this.pin3 = pin3;
            this.pin4 = pin4;
            JeZamceny = true;
            obsahTrezoru.AddRange(pocatecniObsah);
        }

        internal static void VygenerujCiselnyPin(out int pin1, out int pin2, out int pin3, out int pin4)
        {
            Random random = new Random();
            pin1 = random.Next(10);
            pin2 = random.Next(10);
            pin3 = random.Next(10);
            pin4 = random.Next(10);
        }

        public void ZadejKod(int pin1, int pin2, int pin3, int pin4)
        {
            JeZamceny = this.pin1 != pin1 || this.pin2 != pin2 || this.pin3 != pin3 || this.pin4 != pin4;
            if (JeZamceny) throw new TrezorException("Zadany kod trezoru je neplatny.");
        }

        public List<object> ObsahTrezoru
        {
            get
            {
                if (JeZamceny)
                {
                    throw new TrezorException("Obsah neni mozne ziskat. Trezor je zamceny.");
                }

                return obsahTrezoru;
            }
        }
    }
}
