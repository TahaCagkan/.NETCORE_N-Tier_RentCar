using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //Hepsini getir

        List<Brand> GetAll();
        //Car Id sine göre getir
        List<Brand> GetBrandsByColorId(int id);
        //Günlük araba ücreti min max aralığı
    }
}
