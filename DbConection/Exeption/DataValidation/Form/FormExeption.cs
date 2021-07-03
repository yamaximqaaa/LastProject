using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Exeption.DataValidation.Form
{
    public class FormExeption : DataValidation
    {
        public FormExeption(string lineName)
            : base("(Line " + lineName + " not valid)")
        {

        }
    }
}
