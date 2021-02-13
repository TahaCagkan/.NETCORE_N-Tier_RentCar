using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        //Hepsini getir
        IDataResult<List<Brand>> GetAll();
        //Marka Id sine göre getir
        IDataResult<List<Brand>> GetBrandsByColorId(int id);
        //id ye göre getir
        IDataResult<Brand> GetById(int id);

        //Ekle
        IResult Add(Brand entity);
        //Sil
        IResult Delete(Brand entity);
        //Güncelle
        IResult Update(Brand entity);
        
    }
}
