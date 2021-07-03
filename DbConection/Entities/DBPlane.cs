using Entity.Enums;
using Abstractions.Plane;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection.Entities
{
    public class DBPlane : IPlane
    {
        [Key]
        public string planeNum { get; set; }
        public DateTime timeIn { get; set; }
        public DateTime timeOut { get; set; }
        public string city { get; set; }
        public Airline airline { get; set; }
        public Terminal terminal { get; set; }
        public Status status { get; set; }
        public string gate { get; set; }

    }
}
