using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        //car ile ilgili detaylı bilgilere ulaşmak için DTO(Data Transformation Object) kullandık
        List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null);
    }
}
