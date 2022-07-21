using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [ValidationAspect(typeof(CarImageManager))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinnesRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Add(file, PathConstants.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDelete);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinnesRules.Run(CheckCarImage(carId));
            if (result !=null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId==carId));
        }

         
        private DataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult[] CheckCarImage(int carId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagePath + carImage.ImagePath
                , PathConstants.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdate);
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }
    }
}
