using Core.Entities;
using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IResult Add(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>>GetCarDetails();


    }
}
