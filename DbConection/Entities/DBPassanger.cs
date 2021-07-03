using Entity.Enums;
using Abstractions.Passanger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Entities
{
    public  class DBPassanger : IPassenger
    {
        public int planeNum { get; set; }
        public string name { get; set; }
        public string secondName { get; set; }
        public string nationality { get; set; }
        [Key]
        public string passportNum { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public Sex sex { get; set; }
        public Class classF { get; set; }
        public int price { get; set; }
    }
}
