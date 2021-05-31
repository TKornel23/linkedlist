using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_masodiknekifutas
{
    public enum Oldal
    {
        jó, gonosz, civil
    }
    public class SzuperHos
    {
        public string Név { get; set; }
        public int Erő { get; set; }
        public int Gyorsaság { get; set; }
        public bool Mutáns { get; set; }
        public Oldal Oldal { get; set; }

        public SzuperHos(string név, int erő, int gyorsaság, bool mutáns, Oldal oldal)
        {
            this.Név = név;
            this.Erő = erő;
            this.Gyorsaság = gyorsaság;
            this.Mutáns = mutáns;
            this.Oldal = oldal;
        }

        public SzuperHos()
        {

        }
    }
}
