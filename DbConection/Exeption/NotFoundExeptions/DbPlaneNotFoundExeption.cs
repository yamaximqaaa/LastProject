using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Exeption.NotFoundExeptions
{
    public class DbPlaneNotFoundExeption : Exception
    {
        
        public DbPlaneNotFoundExeption()
            : base()
        {

        }
        public DbPlaneNotFoundExeption(string msg, string planeNum)
            : base(msg + " (" + planeNum + " not found)")
        {

        }

    }
}
