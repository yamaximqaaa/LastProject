using Abstractions.Airport;
using Abstractions.Passanger;
using DbConection.Entities;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Passanger : IPassenger
    {
        public string planeNum { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string nationality { get; set; }
        public string passportNum { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public Sex sex { get; set; }
        public Class classF { get; set; }
        public int price { get; set; }

        public static implicit operator DBPassanger(Passanger pass)
        {
            var dbPs = new DBPassanger()
            {
                classF = pass.classF,
                dateOfBirthday = pass.dateOfBirthday,
                name = pass.name,
                nationality = pass.nationality,
                passportNum = pass.passportNum,
                planeNum = pass.planeNum,
                price = pass.price,
                secondName = pass.secondName,
                sex = pass.sex
            };
            return dbPs;
        }
        public static implicit operator Passanger(DBPassanger pass)
        {
            var dbPs = new Passanger()
            {
                classF = pass.classF,
                dateOfBirthday = pass.dateOfBirthday,
                name = pass.name,
                nationality = pass.nationality,
                passportNum = pass.passportNum,
                planeNum = pass.planeNum,
                price = pass.price,
                secondName = pass.secondName,
                sex = pass.sex
            };
            return dbPs;
        }
    }
}
