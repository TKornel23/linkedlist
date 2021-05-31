using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_masodiknekifutas
{
    class Program
    {
        static void Bejaro(string szöveg)
        {
            Console.WriteLine(szöveg);
        }
        static void Main(string[] args)
        {
            IgazsagLigaja igazsagLigaja = new IgazsagLigaja();
            SzuperHos Superman = new SzuperHos("Superman", 100, 100, true, Oldal.jó);
            SzuperHos Wonderwoman = new SzuperHos("Wonderwoman", 90, 100, true, Oldal.jó);
            SzuperHos Joker = new SzuperHos("Joker", 40, 40, false, Oldal.gonosz);
            SzuperHos Batman = new SzuperHos("Batman", 70, 60, false, Oldal.jó);
            SzuperHos Batman2 = new SzuperHos("Batman", 70, 60, false, Oldal.jó);
            IgazsagLigaja masodikLiga = new IgazsagLigaja();

            try
            {
                igazsagLigaja.Beszúrás(Batman);
                igazsagLigaja.Beszúrás(Wonderwoman);
                masodikLiga.Beszúrás(Superman);
                masodikLiga.Beszúrás(Wonderwoman);
                masodikLiga.Beszúrás(Joker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Console.WriteLine("Igazság Ligája");
            igazsagLigaja.Bejárás(Bejaro);
            IgazsagLigaja szűrt = igazsagLigaja.Szűrés(Oldal.jó);
            Console.WriteLine();
            Console.WriteLine("Szűrt liga");
            szűrt.Bejárás(Bejaro);
            Console.WriteLine();
            Console.WriteLine("Második liga");
            masodikLiga.Bejárás(Bejaro);
            Console.WriteLine();
            Console.WriteLine("Metszet");
            IgazsagLigaja metszet = igazsagLigaja.Metszet(masodikLiga);
            metszet.Bejárás(Bejaro);
            Console.WriteLine();
            Console.WriteLine("Unió");
            IgazsagLigaja unio = igazsagLigaja.Unio(masodikLiga);
            unio.Bejárás(Bejaro);
            Console.WriteLine();
            Console.WriteLine("Különbség");
            IgazsagLigaja különbség = masodikLiga.Különbség(igazsagLigaja);
            különbség.Bejárás(Bejaro);
            Console.ReadLine();
        }
    }
}
