using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_masodiknekifutas
{
    class HeroNotFoundException : Exception
    {
        public HeroNotFoundException(string név) :base($"{név} nincs benne a ligában")
        {

        }
    }
}
