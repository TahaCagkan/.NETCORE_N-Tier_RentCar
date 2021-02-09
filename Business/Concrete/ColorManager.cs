using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        //dependency injection
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public List<Color> GetAll()
        {
            //iş kodları
            return _colorDal.GetAll();
        }

        public List<Color> GetColorsByColorId(int id)
        {
            //Her bir Color,benim gönderdiğim Id ye eşit ise onu gönder

            return _colorDal.GetAll(c => c.ColorId == id);
        }
    }
}
