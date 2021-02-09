using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        //Hepsini getir

        List<Color> GetAll();
        //Car Id sine göre getir
        List<Color> GetColorsByColorId(int id);
        //Günlük araba ücreti min max aralığı
    }
}
