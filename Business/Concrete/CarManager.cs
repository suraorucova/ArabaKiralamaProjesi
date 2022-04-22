using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
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


        public IResult Add(Car car)
        {
          if (car.Description.Length>=2&& car.DailyPrice>0)
           {
               _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
           }
            return new ErrorResult(Messages.CarAddedInvalid);
        }

        public IResult Delete(Car car)
        {
            if (car.ModelYear == 2007)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarDeletedInvalid);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==14)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            
          return new SuccessDataResult<List<Car>>( _carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.Id == id));
        }

        public IDataResult< List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
