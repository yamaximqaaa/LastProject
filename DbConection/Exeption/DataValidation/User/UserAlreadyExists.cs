using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Exeption.DataValidation.User
{
    public class UserAlreadyExists : DataValidation
    {
        public UserAlreadyExists(string login)
            : base("(Login " + login +" exists)")
        {

        }
    }
}
