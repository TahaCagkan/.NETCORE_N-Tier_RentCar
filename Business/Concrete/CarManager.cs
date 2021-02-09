using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //dependency injection
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            //iş kodları
            return _carDal.GetAll();
        }

        public List<Car> GetByDaylyUnitPrice(decimal min, decimal max)
        {
            //Girilen fiyat aralığana göre Arabaları getir
            return _carDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max);
        }
        //istediğimiz araba detaylarına göre listelencektir.
        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarsDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            //Her bir Brand,benim gönderdiğim Id ye eşit ise onu gönder

            return _carDal.GetAll(b => b.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            //Her bir Color,benim gönderdiğim Id ye eşit ise onu gönder

            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
