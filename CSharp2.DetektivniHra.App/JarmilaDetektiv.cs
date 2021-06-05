using CSharp2.DetectiveStory.App;
using CSharp2.DetektivniHra.Material;
using CSharp2.DetektivniHra.Studium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.App
{
    public class JarmilaDetektiv : Detektiv
    {
        Doklady doklad;
        Osoba pachatel;

        public JarmilaDetektiv() : base("Jarmila")
        {

        }

        public override void PresunSe(Adresa adresa)
        {
            if (adresa.Equals(Hra.AdresaParku)) base.Obleceni = Obleceni.UborProVysetrovatele;
            if (adresa.Equals(Hra.AdresaNeziskovky)) base.Obleceni = Obleceni.PrevlekProStudenty;
            if (adresa.Equals(Hra.AdresaRestaurace)) base.Obleceni = Obleceni.PrevlekProObsluhuVRestauraci;

            base.PresunSe(adresa);
        }

        public override void ProhledejDukazniMaterial(IReadOnlyList<object> material)
        {
            foreach(IDukazniMaterial dukaz in material)
            {
                dukaz.JeProzkoumany = true;
            }

            base.ProhledejDukazniMaterial(material);
        }

        public override PrihlaskaNaKurz PodejPrihlasku(List<Kurz> kurzy)
        {
            PrihlaskaNaKurz prihlaska = new PrihlaskaNaKurz();
            prihlaska.Registrovany = this;
            prihlaska.Kurz = kurzy.Where(k => k.Typ == TypKurzu.Jednodenni).FirstOrDefault();
            return prihlaska;
        }

        public override void ProhledejBudovu(IReadOnlyList<Mistnost> mistnosti)
        {
            base.ProhledejBudovu(mistnosti);

            foreach(Mistnost mistnost in mistnosti)
            {
                foreach(object o in mistnost.Predmety)
                {
                    Trezor t = o as Trezor;
                    if (t is null) continue;
                    OtevriTrezor(t);
                }
            }
        }

        private void OtevriTrezor(Trezor trezor)
        {
            for(int pin1 = 0; pin1 < 10; pin1++)
            {
                for (int pin2 = 0; pin2 < 10; pin2++)
                {
                    for(int pin3 = 0; pin3 < 10; pin3++)
                    {
                        for(int pin4 = 0; pin4 < 10; pin4++)
                        {
                            try
                            {
                                if (!trezor.JeZamceny) break;
                                trezor.ZadejKod(pin1, pin2, pin3, pin4);
                            }
                            catch
                            {
                                // pokus selhal, spatny pin, jde se dal ...
                            }
                        }
                    }
                }
            }   
            
            if (!trezor.JeZamceny)
            {
                foreach(IDukazniMaterial material in trezor.ObsahTrezoru)
                {
                    material.JeProzkoumany = true;
                    if (material is Doklady)
                    {
                        doklad = material as Doklady;
                    }
                }
            }
        }

        public override INapoj ObjednejNapoj(Osoba osoba)
        {
            if (osoba.Equals(this))
            {
                return new Caj();
            }
            else
            {
                pachatel = osoba;
                return new NapojNaRozvazaniJazyka();
            }
        }

        public override List<Osoba> NajdiVsechnyOsobyKtereNeumiCSharp(List<Osoba> osoby)
        {
            return osoby.Where(osoba => osoba.Dovednost != Dovednost.CSharp).ToList();
        }

        public override VysetrovaciZprava OdevzdejVysetrovaciZpravu()
        {
            return new VysetrovaciZprava()
            {
                KlicovyDukaz = doklad,
                Pachatel = pachatel,
            };
        }
    }
}
