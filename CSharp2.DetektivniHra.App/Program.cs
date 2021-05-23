using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2.DetektivniHra.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hra hra = new Hra(new JarmilaDetektiv());
                hra.Hrej();
            }
            catch(Exception e)
            {
                Console.WriteLine("Behem hry doslo k neocekavanemu problemu, pripad nebyl vyresen.");
                Console.WriteLine("Duvod: " + e);
            }
            finally
            {
                Console.WriteLine("Stiskem libovolne klavesy se program ukonci.");
                Console.ReadKey();
            }
        }
    }
}
