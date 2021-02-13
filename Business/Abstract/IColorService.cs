using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        //Hepsini getir

        IDataResult< List<Color> >GetAll();
        //Color Id sine göre getir
        IDataResult<List<Color>> GetColorsByColorId(int id);
        //id ye göre getir
        IDataResult<Color>GetById(int id);
        //Ekle
        IResult Add(Color entity);
        //Sil
        IResult Delete(Color entity);
        //Güncelle
        IResult Update(Color entity);
    }
}
