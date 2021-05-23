using CSharp2.DetektivniHra.Material;
using CSharp2.DetektivniHra.Mistnosti;
using CSharp2.DetektivniHra.Studium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp2.DetektivniHra
{
    public class Hra
    {
        public static readonly Adresa AdresaParku = new Adresa("Park", 13, "Ostrovidy", 65535);
        public static readonly Adresa AdresaNeziskovky = new Adresa("Vzdelavaci", 1, "Ostrovidy", 65535);
        public static readonly Adresa AdresaRestaurace = new Adresa("Kucharova", 42, "Ostrovidy", 65535);

        public Detektiv Detektiv { get; private set; }
        private readonly Osoba Pachatel = new Osoba("Gvendolina", Pohlavi.Zenske);

        public Hra(Detektiv detektiv)
        {
            if (detektiv is null) throw new ArgumentNullException(nameof(detektiv));

            Detektiv = detektiv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="HraException">Vyhazuje v pripade, ze hra nemuze dal pokracovat.</exception>
        public void Hrej()
        {
            VypisyNaKonzoli.ZobrazUvodDoHry(Detektiv);
            VypisyNaKonzoli.CekejNaStiskKlavesy();

            Detektiv.PresunSe(AdresaParku);
            if (!VypisReakciNaObleceniDoParkuAVratZdaJeVhodne()) return;

            VypisyNaKonzoli.CekejNaStiskKlavesy();
            VypisyNaKonzoli.ZobrazVParkuProhledavaniDukazu(Detektiv);

            Detektiv.ProhledejDukazniMaterial(Park.Material.Cast<object>().ToList());
            if (!VypisReakciNaProhledaniMaterialuAVratZdaJeKompletni(Park.Material)) return;

            VypisyNaKonzoli.CekejNaStiskKlavesy();
            Detektiv.PresunSe(AdresaNeziskovky);
            VypisyNaKonzoli.ZobrazPrichodDoNeziskovky(Pachatel);

            PrihlaskaNaKurz prihlaska = Detektiv.PodejPrihlasku(Neziskovka.SeznamKurzu);
            if (!VypisReakciNaPrihlaskuAVratZdaJeSpravne(prihlaska)) return;
            VypisyNaKonzoli.CekejNaStiskKlavesy();

            Detektiv.PresunSe(AdresaNeziskovky);
            if (!VypisReakciNaObleceniNaKurzAVratZdaJeVhodne()) return;
            VypisyNaKonzoli.CekejNaStiskKlavesy();

            Detektiv.ProhledejBudovu(Neziskovka.Mistnosti);
            if (!VypisReakciNaProhledaniMistnostiAVratZdaDokladyNalezeny(Neziskovka.TrezorVReditelne, Pachatel)) return;
            VypisyNaKonzoli.CekejNaStiskKlavesy();

            VypisyNaKonzoli.ZobrazZadaniDomacihoUkolu();
            List<Osoba> kopieUcastniku = Neziskovka.UcastniciKurzu.ToList();
            List<Osoba> vysledek = Detektiv.NajdiVsechnyOsobyKtereNeumiCSharp(Neziskovka.UcastniciKurzu);
            VypisReakciNaVysledekDomacihoUkoluAVratZdaJeSpravne(kopieUcastniku, vysledek);
            VypisyNaKonzoli.CekejNaStiskKlavesy();

            VypisyNaKonzoli.ZobrazCestaDoRestaurace(Detektiv, Pachatel);
            Detektiv.PresunSe(AdresaRestaurace);
            if (!VypisReakciNaOblecenDoRestauraceAVratZdaJeVhodne(Detektiv, Pachatel)) return;
            VypisyNaKonzoli.CekejNaStiskKlavesy();

            VypisyNaKonzoli.ZobrazOdchodReditelkyNaToalety(Detektiv, Pachatel);
            INapoj napojProGvendolinu = Detektiv.ObjednejNapoj(Pachatel);
            INapoj napojProDetektiva = Detektiv.ObjednejNapoj(Detektiv);
            if (!VypisReakciNaNapojeAVratZdaFungovaly(Detektiv, napojProDetektiva, Pachatel, napojProGvendolinu)) return;

            VypisyNaKonzoli.CekejNaStiskKlavesy();

            VypisyNaKonzoli.ZobrazJeTrebaOdevzdatZpravu(Detektiv);
            VysetrovaciZprava vysetrovaciZprava = Detektiv.OdevzdejVysetrovaciZpravu();
            VypisReakciNaOdevzdanouVysetrovaciZpravu(vysetrovaciZprava, Detektiv, Pachatel);

            VypisyNaKonzoli.ZobrazKonecHry();
        }

        private static void VypisReakciNaOdevzdanouVysetrovaciZpravu(VysetrovaciZprava vysetrovaciZprava, Detektiv detektiv, Osoba pachatel)
        {
            if (vysetrovaciZprava is null)
            {
                VypisyNaKonzoli.ZobrazDetektivNeodevzdalVysetrovaciZpravu(detektiv);
            }
            else
            {
                if (vysetrovaciZprava.JePripadUzavren && vysetrovaciZprava.KlicovyDukaz is Doklady && vysetrovaciZprava.Pachatel.Equals(pachatel))
                {
                    VypisyNaKonzoli.ZobrazDetektivOdevzdalZpravuAPachatelBylUsvedcen(detektiv, pachatel);
                }
                else
                {
                    VypisyNaKonzoli.ZobrazDetektivOdevzdalZpravuAleDukazyNebylyDostatecne(detektiv);
                }
            }
        }

        private static bool VypisReakciNaNapojeAVratZdaFungovaly(Osoba detektiv, INapoj napojProDetektiva, Osoba gvendolina, INapoj napojProGvendolinu)
        {
            if (napojProDetektiva is null || napojProGvendolinu is null)
            {
                VypisyNaKonzoli.ZobrazDetektivNezvladlObjednatNapoje(detektiv, gvendolina);
            } 
            else if (napojProDetektiva.JeAlkoholicky || napojProDetektiva.Prisada == TajnaPrisada.SerumPravdy)
            {
                VypisyNaKonzoli.ZobrazDetektivSiObjednalSpatneAVsechnoVyklopil(detektiv, gvendolina);
            }
            else if (napojProDetektiva.Prisada == TajnaPrisada.Projimadlo)
            {
                VypisyNaKonzoli.ZobrazDetektivSiObjednalProjimadlo(detektiv, gvendolina);
            }
            else if (napojProGvendolinu.Prisada == TajnaPrisada.Projimadlo)
            {
                VypisyNaKonzoli.ZobrazGvendolinaDostalaProjimadlo(detektiv, gvendolina);
            }
            else if (napojProGvendolinu.JeAlkoholicky)
            {
                VypisyNaKonzoli.ZobrazGvendolinaDostalaAlkohol(detektiv, gvendolina);
            }
            else if (napojProGvendolinu.Prisada == TajnaPrisada.SerumPravdy)
            {
                VypisyNaKonzoli.ZobrazGvendolinaDostalaSerumPravdy(detektiv, gvendolina);
                return true;
            }
            else
            {
                VypisyNaKonzoli.ZobrazNapojeBylySuperAleNicSeNezjistilo(detektiv, gvendolina);
            }

            return false;
        }

        private static bool VypisReakciNaOblecenDoRestauraceAVratZdaJeVhodne(Detektiv detektiv, Osoba gvendolina)
        {
            switch (detektiv.Obleceni)
            {
                case Obleceni.PrevlekProObsluhuVRestauraci:
                case Obleceni.SmartCasual:
                case Obleceni.Spolecenske:
                    VypisyNaKonzoli.ZobrazUspechProtozeMaObleceniDoRestaurace(detektiv, gvendolina);
                    return true;
                default:
                    VypisyNaKonzoli.ZobrazNeuspechProtozeNemaObleceniDoRestaurace(detektiv, gvendolina);
                    return false;
            }
        }

        private bool VypisReakciNaVysledekDomacihoUkoluAVratZdaJeSpravne(List<Osoba> kopieUcastniku, List<Osoba> vysledek)
        {
            if (kopieUcastniku is null || vysledek is null)
            {
                VypisyNaKonzoli.VypisDomaciUkolSeNepovedl(Detektiv);
                return false;
            }

            IEnumerable<Osoba> enumerableNeCSharpistu = kopieUcastniku.Where(u => u.Dovednost != Dovednost.CSharp);
            if (!enumerableNeCSharpistu.SequenceEqual(vysledek))
            {
                VypisyNaKonzoli.VypisDomaciUkolSeNepovedl(Detektiv);
                return false;
            }
            else
            {
                VypisyNaKonzoli.VypisDomaciUkolSePovedl(Detektiv);
                return true;
            }
        }

        private static bool VypisReakciNaProhledaniMistnostiAVratZdaDokladyNalezeny(Trezor trezorVReditelne, Osoba gvendolina)
        {
            if (trezorVReditelne.JeZamceny)
            {
                VypisyNaKonzoli.ZobrazNeuspechProtozeTrezorNebylNalezen();
                return false;
            }
            else
            {
                Doklady doklady = trezorVReditelne.ObsahTrezoru.OfType<Doklady>().FirstOrDefault();
                if (doklady != null && doklady.JeProzkoumany)
                {
                    VypisyNaKonzoli.ZobrazUspechProtozeBylyNalezenyDoklady(gvendolina);
                    return true;
                }
                else
                {
                    VypisyNaKonzoli.ZobrazNeuspechProtozeTrezorNebylNalezen();
                    return false;
                }
            }
        }

        private bool VypisReakciNaObleceniNaKurzAVratZdaJeVhodne()
        {
            switch (Detektiv.Obleceni)
            {
                case Obleceni.UborProVysetrovatele:
                    VypisyNaKonzoli.ZobrazNeuspechProtozeMaUborVysetrovatele(Detektiv);
                    return false;
                default:
                    VypisyNaKonzoli.ZobrazUspechProtozeNemaUborVysetrovatele(Detektiv);
                    return true;
            }
        }

        private bool VypisReakciNaPrihlaskuAVratZdaJeSpravne(PrihlaskaNaKurz prihlaska)
        {
            if (prihlaska is null || !prihlaska.JeSpravneVyplnena)
            {
                VypisyNaKonzoli.VypisPrihlaskaSeNepovedlaVyplnit(Detektiv);
            }
            else
            {
                if (prihlaska.Kurz.Typ is TypKurzu.Dlouhodoby)
                {
                    VypisyNaKonzoli.VypisPrihlaskaNaDlouhodobyKurzy(prihlaska);
                }
                else
                {
                    VypisyNaKonzoli.VypisPrihlaskaNaJednodenniKurz(prihlaska);
                    return true;
                }
            }

            return false;
        }

        private bool VypisReakciNaProhledaniMaterialuAVratZdaJeKompletni(List<IDukazniMaterial> dukazniMaterial)
        {
            if (dukazniMaterial.Where(i => !i.JeProzkoumany).Any() || dukazniMaterial.Count != 3)
            {
                VypisyNaKonzoli.ZobrazVMaterialechNicNenalezeno();
                return false;
            }
            else
            {
                VypisyNaKonzoli.ZobrazVMaterialechInfoONeziskovce();
                return true;
            }
        }

        private bool VypisReakciNaObleceniDoParkuAVratZdaJeVhodne()
        {
            switch (Detektiv.Obleceni)
            {
                case Obleceni.Pyzamo:
                    VypisyNaKonzoli.ZobrazNeuspechProtozeNeniPrevlecena();
                    break;
                case Obleceni.UborProVysetrovatele:
                    VypisyNaKonzoli.ZobrazUspechProtozeMaUborVysetrovatele(Detektiv);
                    return true;
                default:
                    VypisyNaKonzoli.ZobrazNeuspechProtozeNemaUborVysetrovatele(Detektiv);
                    break;
            }

            return false;
        }
    }
}
