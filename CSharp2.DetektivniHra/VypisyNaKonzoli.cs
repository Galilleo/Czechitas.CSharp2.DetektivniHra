using CSharp2.DetektivniHra.Studium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra
{
    internal static class VypisyNaKonzoli
    {
        public static void ZobrazUvodDoHry(Detektiv detektiv)
        {
            Console.WriteLine($"Agentka {detektiv.Jmeno} mela jako vzdycky lehke spani.");
            Console.WriteLine("Vzbudila ji prichozi zprava. Nejaka vrazda.");
        }

        public static void ZobrazNeuspechProtozeNeniPrevlecena()
        {
            Console.WriteLine("Chtela se vydat na misto cinu do parku, ale nedokazala se vysoukat z pyzama.");
            Console.WriteLine("A tak zustala doma a vrazdu nevyresila.");
        }

        public static void CekejNaStiskKlavesy()
        {
            Console.Write("Stiskem libovolne klavesy se bude pokracovat ....");
            Console.ReadKey();
            Console.CursorLeft = 0;
            Console.WriteLine(new string(' ', 80));
        }

        internal static void ZobrazNeuspechProtozeNemaUborVysetrovatele(Detektiv detektiv)
        {
            Console.WriteLine($"Vydala se na misto cinu do parku v obleceni {detektiv.Obleceni}.");
            Console.WriteLine("Ale jelikoz nemela vhodne obleceni, nikdo ji k mistu nepustil.");
            Console.WriteLine("A tak zustal pripad nevyresen.");
        }

        internal static void ZobrazUspechProtozeMaUborVysetrovatele(Detektiv detektiv)
        {
            Console.WriteLine($"Hodila na sebe {detektiv.Obleceni} a vydala se na misto cinu do parku..");
        }

        internal static void ZobrazVMaterialechNicNenalezeno()
        {
            Console.WriteLine("V materialech ale nic nenasla a tak zustal pripad nevyreseny");
        }

        internal static void ZobrazPrichodDoNeziskovky(Osoba gvendolina)
        {
            Console.WriteLine($"V Rozvoji ji privitala vedouci pobocky {gvendolina.Jmeno}.");
            Console.WriteLine($"{gvendolina.Jmeno} byla mila. Muze identifikovala. Lektor, ucil programovani. Naprosto bezproblemovy.");
            Console.WriteLine("Promluvila s nekolika lidmi, ale vsechno se zdalo nejak prilis dokonale. Rozhodla se prihlasit do kurzu.");
        }

        internal static void VypisPrihlaskaSeNepovedlaVyplnit(Detektiv detektiv)
        {
            Console.WriteLine($"{detektiv.Jmeno} se prihlaska nepovedla vyplnit, a tak zustal pripad nevyreseny.");
        }

        internal static void ZobrazUspechProtozeNemaUborVysetrovatele(Detektiv detektiv)
        {
            Console.WriteLine($"Rano se {detektiv.Jmeno} prevlekla jako studentka a prestavky na kurzu vyuzila k prozkoumani budovy.");
        }

        internal static void ZobrazZadaniDomacihoUkolu()
        {
            Console.WriteLine("Behem kurzu byl zadan slozity projekt na vyhledani vsech ucastniku, co neumi C#.");
        }

        internal static void ZobrazNeuspechProtozeTrezorNebylNalezen()
        {
            Console.WriteLine("V budove se nepovedlo nic najit, neziskovka je cista jako list papiru. Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazNeuspechProtozeMaUborVysetrovatele(Detektiv detektiv)
        {
            Console.WriteLine($"Rano se {detektiv.Jmeno} vydala do neziskovky, ale vsichni ji tam poznali a celou dobu hlidali.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void VypisDomaciUkolSePovedl(Detektiv detektiv)
        {
            Console.WriteLine($"{detektiv.Jmeno} zvladla na jednicku i zaverecny projekt. Mozna by mohla zvazit zmenu profese ...");
        }

        internal static void ZobrazCestaDoRestaurace(Detektiv detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"Po kurzu se zakecala s {gvendolina.Jmeno} a slovo dalo slovo a obe byly na ceste do fakt super restaurace.");
        }

        internal static void ZobrazJeTrebaOdevzdatZpravu(Detektiv detektiv)
        {
            Console.WriteLine($"{detektiv.Jmeno} mela odevzdat vysetrovaci zpravu.");
        }

        internal static void ZobrazKonecHry()
        {
            Console.WriteLine();
            Console.WriteLine("Hra byla dokoncena :)");
            Console.WriteLine("Vzorove reseni muzete najit zde: https://github.com/Galilleo/Czechitas.CSharp2.DetektivniHra");
        }

        internal static void ZobrazUspechProtozeMaObleceniDoRestaurace(Detektiv detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"Vecer v restauraci mela {detektiv.Jmeno} jediny cil - z {gvendolina.Jmeno} vyrazit info.");
        }

        internal static void ZobrazDetektivOdevzdalZpravuAleDukazyNebylyDostatecne(Detektiv detektiv)
        {
            Console.WriteLine($"{detektiv.Jmeno} odevzdala vysetrovaci zpravu.");
            Console.WriteLine("Dukazy nebyly dostatecne, pachatel nebyl usvedcen a pripad skoncil v supliku.");
        }

        internal static void ZobrazDetektivOdevzdalZpravuAPachatelBylUsvedcen(Osoba detektiv, Osoba pachatel)
        {
            Console.WriteLine($"{detektiv.Jmeno} odevzdala vysetrovaci zpravu.");
            Console.WriteLine($"Dukazy jasne usvedcily {pachatel.Jmeno} a pripad se uzavrel.");
        }

        internal static void ZobrazDetektivNeodevzdalVysetrovaciZpravu(Detektiv detektiv)
        {
            Console.WriteLine($"{detektiv.Jmeno} nemohla zpravu najit a odevzdat.");
            Console.WriteLine($"{detektiv.Jmeno} byla za neschopnost vyhozena a pripad se nikdy nepovedlo vyresit.");
        }

        internal static void ZobrazDetektivNezvladlObjednatNapoje(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} se nepodařilo objednat napoje, {gvendolina.Jmeno} se nudila a nic se nepovedlo zjistit.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazDetektivSiObjednalSpatneAVsechnoVyklopil(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} si popletla napoje a jak se napila, vsechno {gvendolina.Jmeno} vyklopila.");
            Console.WriteLine($"{gvendolina.Jmeno} se zvedla a odesla a uz se s {detektiv.Jmeno} nikdy nebavila.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazGvendolinaDostalaProjimadlo(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} objednala napoj, ve kterem bylo projimadlo a tak se nic nedozvedela. {gvendolina.Jmeno} stravila cely vecer na toaletach.");
            Console.WriteLine($"{gvendolina.Jmeno} nechtela {detektiv.Jmeno} uz nikdy videt.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazNapojeBylySuperAleNicSeNezjistilo(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} objednala napoje, ktere byly super. {gvendolina.Jmeno} byla nadsena a skvele si pokecala.");
            Console.WriteLine($"{detektiv.Jmeno} nic zajimaveho za cely vecer nezjistila.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazGvendolinaDostalaSerumPravdy(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} objednala napoj, ve kterem bylo serum pravdy.");
            Console.WriteLine($"{gvendolina.Jmeno} ji vyklopila uplne vsechno, jak jsou s nim neustale problemy a ma milion blbych kecu.");
            Console.WriteLine("A tak v zapalu zurivosti kvuli dalsim kecum vzala boty s jehlovymi podpatky a zatancovala si na nem Cardas.");
        }

        internal static void ZobrazGvendolinaDostalaAlkohol(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} objednala napoj, ve kterem byl alkohol a tak se nic nedozvedela.");
            Console.WriteLine($"{gvendolina.Jmeno} se pekne striskala a bylo ji dost zle.");
            Console.WriteLine($"{gvendolina.Jmeno} nechtela {detektiv.Jmeno} uz nikdy videt.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazDetektivSiObjednalProjimadlo(Osoba detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} si popletla napoje a jak se napila, spechala rychle na toalety.");
            Console.WriteLine($"{gvendolina.Jmeno} dlouho cekala, ale nakonec odesla a uz se s {detektiv.Jmeno} nikdy nebavila.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazNeuspechProtozeNemaObleceniDoRestaurace(Detektiv detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"{detektiv.Jmeno} ale nemela vhodne obleceni, dovnitr ji nepustili a tak se pripad nepovedlo vyresit.");
        }

        internal static void VypisDomaciUkolSeNepovedl(Detektiv detektiv)
        {
            Console.WriteLine($"{detektiv.Jmeno} vubec nepochopila, co ma za ukol delat. Ale je dulezite, ze ma stopu..");
        }

        internal static void ZobrazUspechProtozeBylyNalezenyDoklady(Osoba gvendolina)
        {
            Console.WriteLine($"V trezoru {gvendolina.Jmeno} byly schovane doklady lektora.");
        }

        internal static void ZobrazVMaterialechInfoONeziskovce()
        {
            Console.WriteLine("V materialech nasla info o nejake neziskovce, co uci, tak se tam rozhodla vydat.");
        }

        internal static void VypisPrihlaskaNaJednodenniKurz(PrihlaskaNaKurz prihlaska)
        {
            Console.WriteLine($"{prihlaska.Registrovany.Jmeno} se prihlasila na jednodenni workshop, ktery se konal nasledujici den.");
        }

        internal static void VypisPrihlaskaNaDlouhodobyKurzy(PrihlaskaNaKurz prihlaska)
        {
            Console.WriteLine($"{prihlaska.Registrovany.Jmeno} se prihlasila na dlouhodoby kurz a chytlo ji to tak moc, ze na pripad uplne zapomnela.");
            Console.WriteLine("Pripad se nepovedlo vyresit.");
        }

        internal static void ZobrazVParkuProhledavaniDukazu(Detektiv detektiv)
        {
            Console.WriteLine("V parku jiz bylo veselo a vsichni prohledavali misto cinu.");
            Console.WriteLine("Zavrazdeny byl muz kolem 40, bez dokladu, bodne rany.");
            Console.WriteLine($"{detektiv.Jmeno} zacala prohledavat nalezene dukazy.");
        }

        internal static void ZobrazOdchodReditelkyNaToalety(Detektiv detektiv, Osoba gvendolina)
        {
            Console.WriteLine($"Kdyz {gvendolina.Jmeno} odesla na toalety, {detektiv.Jmeno} se pokusila objednat napoj,");
            Console.WriteLine($"kam by primichala neco, co by {gvendolina.Jmeno} rozvazalo jazyk.");
        }
    }
}
