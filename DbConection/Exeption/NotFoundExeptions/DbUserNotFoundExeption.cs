using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Exeption.NotFoundExeptions
{
    public class DbUserNotFoundExeption : Exception
    {
        public DbUserNotFoundExeption()
            : base()
        {

        }
        public DbUserNotFoundExeption(string msg, string login)
            : base(msg + " (" + login + " not found)")
        {

        }
    }
}
