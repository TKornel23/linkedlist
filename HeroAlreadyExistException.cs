using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTUTU_masodiknekifutas
{
    class HeroAlreadyExistException : Exception
    {
        public HeroAlreadyExistException() : base("Van már ilyen hős a ligában!")
        {

        }
    }
}
