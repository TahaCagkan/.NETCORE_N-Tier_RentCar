using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        //Ekle
        public IResult Add(Car entity)
        {
            if(entity.CarName.Length<10)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(entity);
            //Result : IResult inherit
            return new SuccessResult(Messages.CarAdded);
        }
        //Silme
        public IResult Delete(Car entity)
        {
            //ilgili id ye göre silincek aracaı car değişkeni içerisine ata
            var car = _carDal.GetById(entity.CarId);
            //boş ise
            if(car == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarDeletedError);

            }
            //degil ise
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            //iş kodları
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult< List<Car>> GetByDaylyUnitPrice(decimal min, decimal max)
        {
            //Girilen fiyat aralığana göre Arabaları getir
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max));
        }
        //idye göre getirme
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        //istediğimiz araba detaylarına göre listelencektir.
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        public IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            //Her bir Brand,benim gönderdiğim Id ye eşit ise onu gönder

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            //Her bir Color,benim gönderdiğim Id ye eşit ise onu gönder

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        //güncelleme
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdate);
        }
    }
}
