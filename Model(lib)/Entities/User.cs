using DbConection.Abstractions.User;
using DbConection.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsEmploee { get; set; }


        #region CastToDBUser

        public static implicit operator DBUser(User user)
        {
            if (user != null)
            {
                return new DBUser()
                {
                    IsEmploee = user.IsEmploee,
                    Password = user.Password,
                    Login = user.Login,
                    LastName = user.LastName,
                    Name = user.Name
                };
            }
            else
            {
                return null;
            }
        }

        public static implicit operator User(DBUser user)
        {
            if (user != null)
            {
                return new User()
                {
                    IsEmploee = user.IsEmploee,
                    Password = user.Password,
                    Login = user.Login,
                    LastName = user.LastName,
                    Name = user.Name
                };
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}
