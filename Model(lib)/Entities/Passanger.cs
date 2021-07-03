using Abstractions.Airport;
using Abstractions.Passanger;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    class Passanger : IPassenger, IAirportObj
    {
        public int planeNum { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string nationality { get; set; }
        public string passportNum { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public Sex sex { get; set; }
        public Class classF { get; set; }
        public int price { get; set; }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
