using Abstractions.Airport;
using Abstractions.Plane;
using DbConection.Collection;
using DbConection.Entities;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Plane : IPlane, IAirportObj, ICloneable
    {
        public string planeNum { get; set; }  // TODO: try to del 
        public DateTime timeIn { get; set; }
        public DateTime timeOut { get; set; }
        public string city { get; set; }
        public Airline airline { get; set; }
        public Terminal terminal { get; set; }
        public Status status { get; set; }
        public string gate { get; set; }

        

        #region PrintMethod

        public void Print()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Plane num: " + this.planeNum.ToString());
            Console.WriteLine("Time in  : " + this.timeIn.ToString());
            Console.WriteLine("Time out : " + this.timeOut.ToString());
            Console.WriteLine("City     : " + this.city.ToString());
            Console.WriteLine("Airline  : " + this.airline.ToString());
            Console.WriteLine("Terminal : " + this.terminal.ToString());
            Console.WriteLine("Status   : " + this.status.ToString());
            Console.WriteLine("Gate     : " + this.gate.ToString());
            Console.WriteLine("===============================");
        }


        public void Print(string key)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CastToDBPlane

        public DBPlane CastToDBPlane()
        {
            var dbPl = new DBPlane()
            {
                airline = airline,
                city = city,
                gate = gate,
                planeNum = planeNum,
                status = status,
                terminal = terminal,
                timeIn = timeIn,
                timeOut = timeOut
            };
            return dbPl;
        }

        public static implicit operator DBPlane(Plane plane)
        {
            var dbPl = new DBPlane()
            {
                airline = plane.airline,
                city = plane.city,
                gate = plane.gate,
                planeNum = plane.planeNum,
                status = plane.status,
                terminal = plane.terminal,
                timeIn = plane.timeIn,
                timeOut = plane.timeOut
            };
            return dbPl;
        }

        public static implicit operator Plane(DBPlane plane)
        {
            var Pl = new Plane()
            {
                airline = plane.airline,
                city = plane.city,
                gate = plane.gate,
                planeNum = plane.planeNum,
                status = plane.status,
                terminal = plane.terminal,
                timeIn = plane.timeIn,
                timeOut = plane.timeOut
            };
            return Pl;
        }

        #endregion

        #region IClonable

        public object Clone()
        {
            return new Plane()
            {
                airline = airline,
                city = city,
                gate = gate,
                planeNum = planeNum,
                status = status,
                terminal = terminal,
                timeIn = timeIn,
                timeOut = timeOut
            };
        }

        #endregion
    }
}

