using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ben InMemory çalışıcam demek
            // CarManager carManager = new CarManager(new InMemoryCarDal()); 
            //ben InMemory çalışıcam demek
            CarManager carManager = new CarManager(new EFCarDal());

            //foreach (var car in carManager.GetAll())
            foreach (var car in carManager.GetByDaylyUnitPrice(150, 200))
            {
                Console.WriteLine(car.CarName+" "+car.ModelYear+" "+car.DailyPrice+" "+car.Description);
            }
        }
    }
}
