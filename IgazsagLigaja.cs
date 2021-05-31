using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_masodiknekifutas
{
    class IgazsagLigaja
    {
        private ListaElem fej;

        public void Beszúrás(SzuperHos tartalom)
        {
            ListaElem uj = new ListaElem();
            uj.Tartalom = tartalom;
            uj.Kovetkezo = fej;

            ListaElem p = this.fej;
            ListaElem e = null;

            if (BenneVan(tartalom))
            {
                throw new HeroAlreadyExistException();
            }
            else
            {
                while (p != null && p.Tartalom.Erő < uj.Tartalom.Erő)
                {
                    e = p;
                    p = p.Kovetkezo;
                }
                if (e == null)
                {
                    uj.Kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    uj.Kovetkezo = p;
                    e.Kovetkezo = uj;
                }
            }
        }

        private bool BenneVan(SzuperHos hős)
        {
            ListaElem uj = new ListaElem();
            ListaElem p = fej;
            uj.Tartalom = hős;

            while(p!= null)
            {
                if(p.Tartalom == hős)
                {
                    return true;
                }
                p = p.Kovetkezo;
            }

            return false;
        }

        public void Keresés(string hős)
        {

            while(fej != null && hős != fej.Tartalom.Név)
            {
                fej = fej.Kovetkezo;                
            }
            if(fej != null)
            {
                Console.WriteLine($"Benne van a ligában {hős}");
            }
            else
            {
                throw new HeroNotFoundException(hős);
            }
        }

        public void Törlés(SzuperHos keresettHős)
        {
            ListaElem p = fej;
            ListaElem e = null;

            while(p != null && !Equals(p.Tartalom, keresettHős))
            {
                e = p;
                p = p.Kovetkezo;
            }
            if(!(p is null))
            {
                if(e is null)
                {
                    fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                throw new HeroNotFoundException(keresettHős.Név);
            }
        }

        public void Törlés(string keresettHős)
        {
            ListaElem p = fej;
            ListaElem e = null;

            while (p != null && p.Tartalom.Név != keresettHős)
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (!(p is null))
            {
                if (e is null)
                {
                    fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
            else
            {
                throw new HeroNotFoundException(keresettHős);
            }
        }

        private new bool Equals(object a, object b)
        {
            SzuperHos hősA = a as SzuperHos;
            SzuperHos HősB = b as SzuperHos;

            if(hősA.Név.Equals(HősB.Név) && hősA.Erő.Equals(HősB.Erő) && hősA.Gyorsaság.Equals(HősB.Gyorsaság) && hősA.Oldal.Equals(HősB.Oldal) && hősA.Mutáns.Equals(HősB.Mutáns))
            {
                return true;
            }

            return false;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public IgazsagLigaja Szűrés(Oldal oldal)
        {
            IgazsagLigaja szűrt = new IgazsagLigaja();
            ListaElem p = fej;

            while (p != null)
            {
                if (p.Tartalom.Oldal == oldal)
                {
                    szűrt.Beszúrás(p.Tartalom);
                }
                p = p.Kovetkezo;
            }

            return szűrt;
        }

        public IgazsagLigaja Szűrés(bool mutánse)
        {
            IgazsagLigaja szűrt = new IgazsagLigaja();
            ListaElem p = fej;

            while (p != null)
            {
                if (p.Tartalom.Mutáns == mutánse)
                {
                    szűrt.Beszúrás(p.Tartalom);
                }
                p = p.Kovetkezo;
            }

            return szűrt;
        }

        public delegate void BejaroHandler(string szöveg);

        public void Bejárás(BejaroHandler metodus)
        {
            BejaroHandler _metodus = metodus;
            ListaElem hős = this.fej;
            while (hős != null)
            {
                _metodus?.Invoke($"Név: {hős.Tartalom.Név}, Erö: {hős.Tartalom.Erő}, Gyorsaság: {hős.Tartalom.Gyorsaság}, Mutáns: {hős.Tartalom.Mutáns}, Oldal: {hős.Tartalom.Oldal}");
                hős = hős.Kovetkezo;
            }
        }

        public IgazsagLigaja Metszet(IgazsagLigaja segedLiga)
        {
            IgazsagLigaja metszet = new IgazsagLigaja();

            ListaElem elsőLiga = this.fej;
            ListaElem másodikLiga = segedLiga.fej;

            while(elsőLiga != null)
            {
                while(másodikLiga != null && másodikLiga.Tartalom != elsőLiga.Tartalom)
                {
                    másodikLiga = másodikLiga.Kovetkezo;
                }
                if(másodikLiga != null && másodikLiga.Tartalom.Név==elsőLiga.Tartalom.Név)
                {
                    metszet.Beszúrás(másodikLiga.Tartalom);
                }
                másodikLiga = segedLiga.fej;
                elsőLiga = elsőLiga.Kovetkezo;
            }
            return metszet;
        }

        public IgazsagLigaja Unio(IgazsagLigaja segedLiga)
        {
            ListaElem első = this.fej;
            ListaElem második = segedLiga.fej;

            IgazsagLigaja unió = new IgazsagLigaja();

            while(első != null && második != null)
            {
                if(első.Tartalom.Erő > második.Tartalom.Erő)
                {
                    unió.Beszúrás(első.Tartalom);
                    első = első.Kovetkezo;
                }
                else if(első.Tartalom.Erő < második.Tartalom.Erő)
                {
                    unió.Beszúrás(második.Tartalom);
                    második = második.Kovetkezo;
                }
                else
                {
                    unió.Beszúrás(második.Tartalom);
                    második = második.Kovetkezo;
                    első = első.Kovetkezo;
                }
            }

            if(első == null && második != null)
            {
                unió.Beszúrás(második.Tartalom);
                második = második.Kovetkezo;
            }
            else if(első != null && második == null)
            {
                unió.Beszúrás(első.Tartalom);
                első = első.Kovetkezo;
            }

            return unió;
        }

        public IgazsagLigaja Különbség(IgazsagLigaja kértLiga)
        {
            ListaElem első = this.fej;
            ListaElem második = kértLiga.fej;

            IgazsagLigaja különbség = new IgazsagLigaja();

            while(első != null && második != null)
            {
                if(első.Tartalom.Erő < második.Tartalom.Erő)
                {
                    különbség.Beszúrás(első.Tartalom);
                    első = első.Kovetkezo;
                }
                else if(első.Tartalom.Erő > második.Tartalom.Erő)
                {
                    második = második.Kovetkezo;
                }
                else
                {
                    második = második.Kovetkezo;
                    első = első.Kovetkezo;
                }
            }
            while(első != null)
            {
                különbség.Beszúrás(első.Tartalom);
                első = első.Kovetkezo;
            }

            return különbség;
        }
    }
}
