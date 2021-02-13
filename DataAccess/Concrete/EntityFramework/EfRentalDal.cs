using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using(ReCapContext context = new ReCapContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on re.CarId equals cr.CarId
                             join cs in context.Customers on re.CustomerId equals cs.Id
                             join us in context.Users on cs.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CarName = cr.CarName,
                                 CustomerName = cs.CompanyName,
                                 CarId = cr.CarId,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = us.FirstName + " " + us.LastName
                             };


                return result.ToList();
            }
        }
    }
}
