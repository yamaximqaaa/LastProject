using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Exeption.DataValidation
{
    public class DataValidation : Exception
    {
        public DataValidation(string msg)
            : base(msg)
        {

        }
    }
}
