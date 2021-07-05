using Abstractions.Plane;
using DbConection.Context;
using DbConection.Entities;
using DbConection.Exeption;
using DbConection.Exeption.NotFoundExeptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConection
{
    public static class ConnToDb
    {
        static private AirportContext airportDB;

        #region AddDataToTable
        public static void AddPlane(DBPlane plane)
        {
            using (airportDB = new AirportContext())
            {
                airportDB.Planes.Add(plane);
                airportDB.SaveChanges();
            }
        }
        public static void AddPassanger(DBPassanger passanger)
        {
            using (airportDB = new AirportContext())
            {
                airportDB.Passangers.Add(passanger);
                airportDB.SaveChanges();
            }
        }
        public static void AddUser(DBUser user)
        {
            using (airportDB = new AirportContext())
            {
                airportDB.Users.Add(user);
                airportDB.SaveChanges();
            }
        }
        #endregion

        #region GetDataFromTable


        #region GetByKeyValue
        public static DBPlane GetPlane(string planeNum_)
        {
            DBPlane targetPlane;
            using (airportDB = new AirportContext())
            {
                targetPlane = airportDB.Planes.Find(planeNum_);
            }
            if (targetPlane == null)
                throw new DbPlaneNotFoundExeption("No such plane in DB", planeNum_);
            else
                return targetPlane;
        }
        public static DBPassanger GetPassanger(string passportNum_)
        {
            DBPassanger targetPassanger;
            using (airportDB = new AirportContext())
            {
                targetPassanger = airportDB.Passangers.Find(passportNum_);
            }
            if (targetPassanger == null)
                throw new DbPassangerNotFoundExeption("No such passanger in DB", passportNum_);
            else
                return targetPassanger;
        }
        public static DBUser GetUser(string login)
        {
            DBUser targetUser;
            using (airportDB = new AirportContext())
            {
                targetUser = airportDB.Users.Find(login);
            }
            if (targetUser == null)
                throw new DbUserNotFoundExeption("No such user in DB", login);
            else
                return targetUser;
        }
        

        #endregion

        #region GetDataSet

        public static List<DBPlane> GetPlanes()
        {
            using (airportDB = new AirportContext())
            {
                var planes = from item in airportDB.Planes
                             select item;
                airportDB.Planes.Load();
                return planes.ToList();
            }
        }
        public static List<DBPlane> GetPlaneAfterDate(DateTime date)
        {
            using (airportDB = new AirportContext())
            {
                var planes = from item in airportDB.Planes
                             where item.timeOut>date select item;
                airportDB.Planes.Load();
                return planes.ToList();
            }
        }
        public static List<String> GetPlaneNums()
        {
            using (airportDB = new AirportContext())
            {
                var planeNums = from plane in airportDB.Planes
                                select plane.planeNum;
                airportDB.Planes.Load();
                return planeNums.ToList();
            }
        }
        public static List<DBPassanger> GetPassangerByPlane(string planenum)
        {
            using (airportDB = new AirportContext())
            {
                var passangers = from passanger in airportDB.Passangers
                                 where passanger.planeNum.Equals(planenum)
                                 select passanger;
                airportDB.Passangers.Load();
                return passangers.ToList();
            }
        }
        #endregion


        #endregion

        #region DelDataFromTable

        public static void DelPlane(string planeNum)
        {
            using (airportDB = new AirportContext())
            {
                if (airportDB.Planes.Find(planeNum) == null)
                {
                    throw new DbPlaneNotFoundExeption("Plane not found", planeNum);
                }
                else
                {
                    var planeToDel = new DBPlane()
                    {
                        planeNum = planeNum
                    };
                    using (airportDB = new AirportContext())
                    {
                        airportDB.Planes.Attach(planeToDel);
                        airportDB.Planes.Remove(planeToDel);
                        airportDB.SaveChanges();
                    }
                }
            }

        }
        public static void DelPassenger(string passportNum)
        {
            using (airportDB = new AirportContext())
            {
                if (airportDB.Passangers.Find(passportNum) == null)
                {
                    throw new DbPassangerNotFoundExeption("Passanger not found", passportNum);
                }
                else
                {
                    var passangerToDel = new DBPassanger()
                    {
                        passportNum = passportNum
                    };
                    using (airportDB = new AirportContext())
                    {
                        airportDB.Passangers.Attach(passangerToDel);
                        airportDB.Passangers.Remove(passangerToDel);
                        airportDB.SaveChanges();
                    }
                }
            }

        }
        public static void DelUser(string login)
        {
            using (airportDB = new AirportContext())
            {
                if (airportDB.Users.Find(login) == null)
                {
                    throw new DbUserNotFoundExeption("User not found", login);
                }
                else
                {
                    var userToDel = new DBUser()
                    {
                        Login = login
                    };
                    using (airportDB = new AirportContext())
                    {
                        airportDB.Users.Attach(userToDel);
                        airportDB.Users.Remove(userToDel);
                        airportDB.SaveChanges();
                    }
                }
            }
        }

        #endregion
    }
}
