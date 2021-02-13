using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        //ekleme
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.ColorAdded);

        }
        //silme
        public IResult Delete(Color entity)
        {
            //ilgili id ye göre silincek aracaı marka değişkeni içerisine ata
            var color = _colorDal.GetById(entity.ColorId);
            //boş ise
            if (color == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorDeletedError);

            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);

        }

        public IDataResult<List<Color>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }
        //idye göre getirme
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        public IDataResult<List<Color>> GetColorsByColorId(int id)
        {
            //Her bir Color,benim gönderdiğim Id ye eşit ise onu gönder

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id));
        }
        //güncelleme
        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.ColorUpdate);
        }
    }
}
