using Core.Entities;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{ Id=1, BrandId=1, ColorId=1, DailyPrice=2000, ModelYear=2015,
                    Description="2015 model BMW "},
                new Car{Id=2, BrandId=2, ColorId=2, DailyPrice=1500, ModelYear=2007,
                    Description="2007 model Jeep"},
                 new Car{ Id=3, BrandId=3, ColorId=3, DailyPrice=2500, ModelYear=2005,
                    Description="2005 model Land-Rover "},
                new Car{Id=4, BrandId=4, ColorId=4, DailyPrice=2300, ModelYear=2001,
                    Description="2001 model Kia"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            carToUpdate.BrandId = 5;
            carToUpdate.ModelYear = 2008;
            carToUpdate.DailyPrice = 2700;
            carToUpdate.Description = "2008 model Honda";
        }
    }
}
