using CSharp2.DetektivniHra.Material;
using CSharp2.DetektivniHra.Studium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra
{
    /// <summary>
    /// Třída reprezentující v detektivní hře osobu.
    /// </summary>
    public class Osoba : IEquatable<Osoba>
    {
        public string Jmeno { get; private set; }
        public Pohlavi Pohlavi { get; private set; }
        public Obleceni Obleceni { get; set; }
        public bool JeZivy { get; private set; }
        public Dovednost Dovednost { get; set; }

        public Osoba(string jmeno, Pohlavi pohlavi, Obleceni obleceni = Obleceni.SmartCasual, bool jeZivy = true)
        {
            Jmeno = jmeno;
            Pohlavi = pohlavi;
            Obleceni = obleceni;
            JeZivy = jeZivy;
        }

        public virtual void PresunSe(Adresa adresa)
        {
            if (!JeZivy) throw new HraException("Mrtve osoby se zatim neumi presouvat.");
        }

        public virtual PrihlaskaNaKurz PodejPrihlasku(List<Kurz> kurzy)
        {
            if (!JeZivy) throw new HraException("Mrtve osoby se zatim neumi prihlasovat na kurzy.");

            return null;
        }

        public virtual List<Osoba> NajdiVsechnyOsobyKtereNeumiCSharp(List<Osoba> osoby)
        {
            if (!JeZivy) throw new HraException("Mrtve osoby nesmi uz nikoho hledat.");

            return null;
        }

        public virtual INapoj ObjednejNapoj(Osoba osoba)
        {
            if (!JeZivy) throw new HraException("Mrtve osoby zatim objednavat napoje neumi.");

            return null;
        }

        public bool Equals(Osoba other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Compare(Jmeno, other.Jmeno, StringComparison.CurrentCultureIgnoreCase) == 0 &&
                Pohlavi == other.Pohlavi &&
                Obleceni == other.Obleceni &&
                JeZivy == other.JeZivy &&
                Dovednost == other.Dovednost;
        }
    }
}
