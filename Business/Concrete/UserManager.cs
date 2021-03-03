using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        
        }
        List<OperationClaim> IUserService.GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public IResult Add(User user)
        {
            //Result : IResult inherit
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            var userDel = _userDal.GetById(user.Id); 
            if (user == null)
            {
                return new ErrorDataResult<List<User>>(Messages.CarDeletedError);

            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdate);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

    
    }
}
