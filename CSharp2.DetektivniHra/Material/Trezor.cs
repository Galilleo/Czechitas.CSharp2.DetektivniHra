using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.Material
{
    public class Trezor
    {
        private string pin;
        public bool JeZamceny { get; private set; }
        
        List<object> obsahTrezoru = new List<object>();

        public Trezor(string pin, List<object> pocatecniObsah)
        {
            this.pin = pin;
            JeZamceny = true;
            obsahTrezoru.AddRange(pocatecniObsah);
        }

        public static string VygenerujCiselnyPin()
        {
            Random random = new Random();
            string novyPin = string.Empty;
            while(novyPin.Length < 4)
            {
                novyPin += random.Next(10).ToString();
            }

            return novyPin;
        }

        public void ZadejKod(string kod)
        {
            if (kod == null) JeZamceny = true;
            kod = kod.PadLeft(4, '0');
            if (kod == pin) JeZamceny = false;
            else throw new TrezorException("Zadany kod trezoru je neplatny.");
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
