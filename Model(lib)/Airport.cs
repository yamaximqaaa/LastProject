using Entity.Enums;
using DbConection;
using DbConection.Collection;
using DbConection.Entities;
using DbConection.Exeption.DataValidation.User;
using DbConection.Exeption.NotFoundExeptions;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Model
{
    public static class Airport
    {
        #region User

        #region GetUser

        public static User GetUser(string login, string password)
        {
            User user = ConnToDb.GetUser(login);
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        #endregion

        #region AddUser

        public static bool AddUser(User user)
        {
            try
            {
                ConnToDb.AddUser(ValidateUser(user));
                return true;
            }
            catch (Exception e)        // TODO: Custom exeption
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void DelUser(string login)
        {
            ConnToDb.DelUser(login);
        }

        public static async Task<bool> AddUserAsync(User user)
        {
            var result = await Task.Run(() => AddUser(user));
            return result;
        }

        #region ValidateUser

        private static User ValidateUser(User user)
        {
            try
            {
                if (ConnToDb.GetUser(user.Login).Login == user.Login)
                {
                    throw new UserAlreadyExists(user.Login);
                }
                else
                {
                    return ValidateFields(user);
                }
            }
            catch (DbUserNotFoundExeption)
            {
                return ValidateFields(user);
            }

        }

        private static User ValidateFields(User user)
        {
            if (IsStringCorrect(user.Login) &&
                IsStringCorrect(user.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }


        #endregion

        #endregion

        public static bool IsUserEmploee(string login, string password)
        {
            DBUser user;
            try
            {
                user = ConnToDb.GetUser(login);
            }
            catch (DbUserNotFoundExeption )
            {
                return false;
                throw;
            }


            if (user == null)
            {
                return false;
            }
            else
            {
                if (user.IsEmploee && user.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        

        public static async Task<bool> IsUserEmploeeAsync(string login, string password)
        {
            var result = await Task.Run(() => IsUserEmploee(login, password));
            return result;
        }


        #endregion

        #region AddGetPlane

        public static List<String> GetAllPlaneNums()
        {
            return ConnToDb.GetPlaneNums();
        }

        public static List<Plane> GetPlanes()
        {
            List<Plane> list = new List<Plane>();
            foreach (var item in ConnToDb.GetPlanes())
            {
                list.Add(item);
            }
            return list;
        }
        
        public static DBPlane GetPlane(string planeNum)
        {
            try
            {
                var result = ConnToDb.GetPlane(planeNum);
                return result;
            }
            catch (DbPlaneNotFoundExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static List<Plane> GetPlaneAfterDate(DateTime date)
        {
            ;
            List<Plane> list = new List<Plane>();
            foreach (var item in ConnToDb.GetPlaneAfterDate(date))
            {
                list.Add(item);
            }
            return list;
        }

        public static bool AddPlane(Plane plane)
        {
            try
            {
                ConnToDb.AddPlane(plane);
                return true;
            }
            catch (Exception e)        // TODO: Custom exeption
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #region AddGetPlaneAsync

        public static async Task<DBPlane> GetPlaneAsync(string planeNum)
        {
            try
            {
                var result = await Task.Run(() => ConnToDb.GetPlane(planeNum));
                return result;
            }
            catch (DbPlaneNotFoundExeption e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static async Task<bool> AddPlaneAsync(Plane plane)
        {
            var result = await Task.Run(() => AddPlane(plane));
            return result;
        }

        #endregion

        #endregion

        #region AddGetPassangers

        public static List<Passanger> GetPassangersByPlane(string planeNum)
        {
            List<Passanger> pass = new List<Passanger>();
            foreach (var pas in ConnToDb.GetPassangerByPlane(planeNum))
            {
                pass.Add(pas);
            }
            return pass;
        }

        #endregion

        #region DelPlane

        public static void DelPlane(string planeNum)
        {
            try
            {
                ConnToDb.DelPlane(planeNum);
            }
            catch (DbPlaneNotFoundExeption e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion

        #region StringCheck

        private static bool IsStringCorrect(string strToCheck)
        {
            if (strToCheck == "")
            {
                return false;
            }
            else
            {
                if (strToCheck.Contains(" "))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion

        #region AditionalMethods

        public static int GetDayPart()
        {
            var now = DateTime.Now;
            if (0 <= now.Hour && now.Hour < 6)
            {
                return (int)DayPart.Night;
            }
            else if (6 <= now.Hour && now.Hour < 12)
            {
                return (int)DayPart.Morning;
            }
            else if (12 <= now.Hour && now.Hour < 18)
            {
                return (int)DayPart.Afternoon;
            }
            else if (18 <= now.Hour && now.Hour < 24)
            {
                return (int)DayPart.Evening;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public static int GetPrice(Class classF, Airline airline)
        {
            int price = 0;
            switch (classF)
            {
                case Class.Econom: price += 1000;
                    break;
                case Class.Business: price += 5000;
                    break;
                default: throw new Exception("Choose class");
            }
            switch (airline)
            {
                case Airline.UkraineInternationalAirlines: price = (int)Math.Round(price * 1.2);
                    break;
                case Airline.Windrose: price = (int)Math.Round(price * 1.3);
                    break;
                case Airline.SkyUpAirlines: price = (int)Math.Round(price * 1.4);
                    break;
                case Airline.AzurAirUkraine:  price = (int)Math.Round(price * 1.5);
                    break;
                default:
                    throw new Exception("Choose class");
            }
            return price;
        }
        #endregion

        public static void AddPassanger(Passanger pas)
        {
            ConnToDb.AddPassanger(pas);
        }
        public static void DelPassanger(string passportNum)
        {
            ConnToDb.DelPassenger(passportNum);
        }

    }
}
