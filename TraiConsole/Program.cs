using Abstractions.Plane;
using DbConection;
using DbConection.Context;
using DbConection.Entities;
using DbConection.Exeption;
using DbConection.Exeption.NotFoundExeptions;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TraiConsole
{
    class Program
    {
        static void Loading()
        {
            Console.Write(@"\");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write(@"|");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write(@"/");
            Thread.Sleep(100);
            Console.Write("\b");
            Console.Write(@"-");
            Thread.Sleep(100);
            Console.Write("\b");
        }
        static void Main(string[] args)
        {
            //var result = Airport.GetPlaneAsync("LO14234");
            //Console.CursorVisible = false;
            //do
            //{
            //    Loading();
            //} while (!result.IsCompleted);
            //Console.CursorVisible = true;
            //Console.WriteLine(result.Result.planeNum);


            //if (result.Result != null)
            //{
            //    Plane pl = result.Result;
            //    pl.Print();
            //}
            //else
            //{
            //    Console.WriteLine("No such plane");
            //}

            //Airport.AddUser(new User()
            //{
            //    Name = "name1",
            //    LastName = "last1",
            //    Login = "login1",
            //    Password = "pass1",
            //    IsEmploee = true
            //});

            //using (AirportContext airportDB = new AirportContext())
            //{
            //    var planes = from item in airportDB.Planes
            //                 select item;
            //    airportDB.Planes.Load();
            //    var listPlanes = planes.ToList();
            //    foreach (var item in listPlanes)
            //    {
            //        Console.WriteLine(item.planeNum);
            //    }
            //}

            var planes = Airport.GetPlanes();

            Console.ReadLine();
        }
    }
}
