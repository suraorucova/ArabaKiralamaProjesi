using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car car)
        {
          if (car.Description.Length>=2&& car.DailyPrice>0)
           {
               _carDal.Add(car);
           }
          else
           {
              Console.WriteLine("Araba eklenmedi"+": Araba--Id:"+car.BrandId);
           }
        }

        public void Delete(Car car)
        {
            if (car.ModelYear == 2007)
            {
                _carDal.Delete(car);
            }
            else
            {
                Console.WriteLine("2007 model araba bulunamadi");
            }
        }

        public List<Car> GetAll()
        {
            
          return  _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
