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

        List<Car> GetAll();
        //Car Id sine göre getir
        List<Car> GetCarsByBrandId(int id);
        //Color Id sine göre getir
        List<Car> GetCarsByColorId(int id);
        //Günlük araba ücreti min max aralığı
        List<Car> GetByDaylyUnitPrice(decimal min, decimal max);
        //istediğimiz özelliklere göre araba listelencektir.
        List<CarDetailDto> GetCarDetails();
    }
}
