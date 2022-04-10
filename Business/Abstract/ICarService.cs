using Core.Entities;
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
        List<Car> GetAll();
        List<Car> GetById(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        void Add(Car car);
        void Delete(Car car);
        List<CarDetailDto> GetCarDetails();


    }
}
