﻿using CSharp2.DetektivniHra.Material;
using CSharp2.DetektivniHra.Mistnosti;
using CSharp2.DetektivniHra.Studium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra
{
    public static class Neziskovka
    {
        public static readonly List<Osoba> UcastniciKurzu;

        public static readonly List<Kurz> SeznamKurzu;

        public static readonly List<Mistnost> Mistnosti;

        internal static string PinTrezoru { get; private set; }
        internal static Trezor TrezorVReditelne { get; private set; }

        static Neziskovka()
        {
            UcastniciKurzu = new List<Osoba>();
            Random random = new Random();
            Dovednost[] dovednosti = Enum.GetValues(typeof(Dovednost)).Cast<Dovednost>().ToArray();

            int pocetUcastniku = random.Next(50);
            for (int i = 0; i < pocetUcastniku; i++)
            {
                Osoba ucastnik = new Osoba(Jmena.Seznam[random.Next(Jmena.Seznam.Length)], Pohlavi.Zenske)
                {
                    Dovednost = dovednosti[random.Next(dovednosti.Length)],
                };

                UcastniciKurzu.Add(ucastnik);
            }

            SeznamKurzu = new List<Kurz>()
            {
                new Kurz("Ovladnuti Emoci", TypKurzu.Dlouhodoby),
                new Kurz("Navrhove Vzory", TypKurzu.Dlouhodoby),
                new Kurz("Uvod do CSharpu", TypKurzu.Jednodenni),
                new Kurz("Programovani a jeho vliv na rostliny", TypKurzu.Jednodenni),
            };

            PinTrezoru = Trezor.VygenerujCiselnyPin();
            TrezorVReditelne = new Trezor(PinTrezoru, new List<object>() { new Doklady() });

            Mistnosti = new List<Mistnost>()
            {
                new Recepce(),
                new Kurarna(),
                new DamskeToalety(),
                new Trida(),
                new Reditelna(new List<object>() { TrezorVReditelne }),
            };
        }
    }
}
