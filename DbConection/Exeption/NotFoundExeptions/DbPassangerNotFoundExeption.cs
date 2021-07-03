using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Exeption.NotFoundExeptions
{
    public class DbPassangerNotFoundExeption : Exception
    {

        public DbPassangerNotFoundExeption()
            : base()
        {

        }
        public DbPassangerNotFoundExeption(string msg, string passportNum)
            : base(msg + " (" + passportNum + " not found)")
        {

        }
    }
}
