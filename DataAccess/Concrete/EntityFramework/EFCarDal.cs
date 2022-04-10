using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (Context context= new Context())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName
                             };
                return result.ToList();
                    
            }
        }
    }
}
