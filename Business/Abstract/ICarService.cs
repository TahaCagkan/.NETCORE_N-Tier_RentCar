using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        //Hepsini getir
        IDataResult<List<Car>> GetAll();
        //Car Id sine göre getir
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        //Color Id sine göre getir
        IDataResult< List<Car>> GetCarsByColorId(int id);
        //Günlük araba ücreti min max aralığı
        IDataResult<List<Car>> GetByDaylyUnitPrice(decimal min, decimal max);
        //istediğimiz özelliklere göre araba listelencektir.
        IDataResult<List<CarDetailDto>> GetCarDetails();
        //id ye gmre getir
        IDataResult<Car> GetById(int id);
        //Ekle
        IResult Add(Car entity);
        //Sil
        IResult Delete(Car entity);
        //Güncelle
        IResult Update(Car entity);
    }
}
