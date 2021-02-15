using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    //ICarDal miras alınarak implement edildi
    public class InMemoryCarDal : ICarDal
    {
        //Car listesini _car değişkeni ile tutyoruz,dependency injection yapmak için.
        List<Car> _car;
        //constructor
        public InMemoryCarDal()
        {
            //bellekte Car bilgileri oluşturuldu.
            _car = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,CarName="ACar", ModelYear="2019", DailyPrice=180000, Description="Son Model"},
                new Car{CarId=1,BrandId=2,ColorId=2,CarName="ACar", ModelYear="2020", DailyPrice=200000, Description="Son Full Model"},
                new Car{CarId=2,BrandId=1,ColorId=3,CarName="BCar", ModelYear="2021", DailyPrice=400000, Description="Lüx Model"},
                new Car{CarId=3,BrandId=1,ColorId=4,CarName="DCar", ModelYear="2022", DailyPrice=900000, Description="Elektrikli Lüx Model"},

            };

        }
        //Ekleme
        public void Add(Car car)
        {
            _car.Add(car);
        }
        //Silme 
        public void Delete(Car car)
        {
            //Gönderdiğim car id'sine sahip olan listedeki car bul,LINQ
            Car carToDelete = _car.FirstOrDefault(c => c.CarId == car.CarId);
            //carToDelete içerisinde attığımız değişkeni bulduktan sonra sil
            _car.Remove(carToDelete);
        }
        //Güncelleme 
        public void Update(Car car)
        {
            //Gönderdiğim car id sine sahip olan listedeki car bul
            Car carToUpdate = _car.FirstOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            
        }


        //Tüm Car ları listelemek 
        public List<Car> GetAll()
        {
            return _car;
        }

        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
