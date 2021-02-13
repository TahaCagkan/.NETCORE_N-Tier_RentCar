using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult ChkReturnDate(int carId)
        {
            var chkResult = _rentalDal.GetRentalDetails(x => x.CarId == carId);

            if( chkResult.Count > 0 && (chkResult.Count(x => x.ReturnDate == null) > 0))
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            var rentalDel = _rentalDal.GetById(rental.Id);
            if (rental == null)
            {
                return new ErrorDataResult<List<User>>(Messages.RentalDeletedError);

            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(x => x.CarId == carId));
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(x => x.CarId == carId);
            var lastUpdatedRental = result.LastOrDefault();
            if (lastUpdatedRental.ReturnDate == null)
            {
                return new ErrorDataResult<List<User>>(Messages.RentalUpdateError);
            }

            lastUpdatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(lastUpdatedRental);

            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
