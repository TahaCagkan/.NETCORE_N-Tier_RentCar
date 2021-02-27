using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.ImageUploadHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {      

        ICarImagesDal _carImagesDal;
      
        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = ImagesUploadHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(IFormFile file, CarImages carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImagesDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = ImagesUploadHelper.UpdateAsync(oldpath, file);
            carImage.Date = DateTime.Now;
            _carImagesDal.Update(carImage);
            return new SuccessResult();

        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Delete(CarImages carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImagesDal.Get(p => p.Id == carImage.Id).ImagePath;

            IResult result = BusinessRules.Run(
                ImagesUploadHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImagesDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImages> Get(int carId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.Id == carId));
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(result.Message);
            }

            return new SuccessDataResult<List<CarImages>>(CheckIfCarImageNull(id).Data);
        }
        //çek etme şayet image yüklenmemiş ise
        private IDataResult<List<CarImages>> CheckIfCarImageNull(int carId)
        {
            string imagePath = @"\Images\default.jpg";
            var result = _carImagesDal.GetAll(x => x.CarId == carId).Any();
            try
            {
                if (!result)
                {
                    List<CarImages> carImage = new List<CarImages>();
                    carImage.Add(new CarImages { CarId = carId, ImagePath = imagePath, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImages>>(carImage);
                }
            }        
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImages>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(p => p.CarId == carId).ToList());
        }
            //5 limit den büyük e
            private IResult CheckIfImageLimit(int carId)
        {
            var carImageCount = _carImagesDal.GetAll(x => x.CarId == carId).Count;
            if (carImageCount <= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }

      
    }
}
