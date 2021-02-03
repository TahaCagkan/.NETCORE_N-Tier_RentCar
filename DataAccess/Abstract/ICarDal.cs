using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //List tipindeki Car class Hepsini Al Methodu
        List<Car> GetAll();
        //Ekleme
        void Add(Car car);
        //Güncelleme
        void Update(Car car);
        //Silme
        void Delete(Car car);
    }
}
