using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            //if(entity.CarName.Length<10)
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
            //ValidationTool.Validate(new CarValidator(), entity);
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

        [CacheAspect]
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
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        //istediğimiz araba detaylarına göre listelencektir.
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        [CacheAspect]
        public IDataResult< List<Car>> GetCarsByBrandId(int id)
        {
            //Her bir Brand,benim gönderdiğim Id ye eşit ise onu gönder

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            //Her bir Color,benim gönderdiğim Id ye eşit ise onu gönder

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        //güncelleme
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdate);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);

            if(car.DailyPrice < 20)
            {
                throw new Exception("20 birim fiyatını yi geçemez!!!!");
            }
            Add(car);

            return null;
        }
    }
}
