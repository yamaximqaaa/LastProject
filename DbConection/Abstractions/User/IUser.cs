using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Abstractions.User
{
    public interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        bool IsEmploee { get; set; }
    }
}
