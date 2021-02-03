using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ben InMemory çalışıcam demek
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {               
                Console.WriteLine(car.CarName+" "+car.ModelYear+" "+car.DailyPrice+" "+car.Description);
            }
        }
    }
}
