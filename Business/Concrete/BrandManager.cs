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
    public class BrandManager : IBrandService
    {
        //dependency injection
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        //ekleme
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.BrandAdded);

        }
        //silme
        public IResult Delete(Brand entity)
        {
            //ilgili id ye göre silincek aracaı marka değişkeni içerisine ata
            var brand = _brandDal.GetById(entity.BrandId);
            //boş ise
            if (brand == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.BrandDeletedError);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);

        }
        //tüm hepsini listele
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetBrandsByColorId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id));
        }
        //idye göre getirme
        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=> b.BrandId == brandId));
        }
        //güncelleme
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.BrandUpdate);
        }
    }
}
