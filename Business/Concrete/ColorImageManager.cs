using Business.Abstract;
using Business.Constants;
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
    public class ColorImageManager : IColorImageService
    {
        IColorImageDal _colorImageDal;
        IFileHelper _fileHelper;

        public ColorImageManager(IFileHelper fileHelper,IColorImageDal colorImageDal)
        {
            _colorImageDal = colorImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ColorImage colorImage)
        {
            IResult result = BusinnesRules.Run(CheckIfColorImageLimit(colorImage.ColorId));
            if (result!=null)
            {
                return new ErrorResult();
            }

            colorImage.ImagePath = _fileHelper.Add(file, PathConstants.ImagePath);
            colorImage.Date = DateTime.Now;

            _colorImageDal.Add(colorImage);
            return new SuccessResult(Messages.ColorImageAdded);
        }

        private IResult CheckIfColorImageLimit(int colorId)
        {
            var result = _colorImageDal.GetAll(c => c.ColorId == colorId).Count;
            if (result>1)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(ColorImage colorImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath+colorImage.ImagePath);
            _colorImageDal.Delete(colorImage);
            return new SuccessResult(Messages.ColorImageDeleted);
        }

        public IDataResult<List<ColorImage>> GetAll()
        {
            return new SuccessDataResult<List<ColorImage>>(_colorImageDal.GetAll());
        }

        public IDataResult< List<ColorImage>>GetByColorId(int colorId)
        {
            var result = BusinnesRules.Run(CheckColorImage(colorId));
            if (result!=null)
            {
                return new ErrorDataResult<List<ColorImage>>(GetDefaultImage(colorId).Data);
            }
            return new SuccessDataResult<List<ColorImage>>(_colorImageDal.GetAll());
        }

        private DataResult<List<ColorImage>> GetDefaultImage(int colorId)
        {
            List<ColorImage> colorImage = new List<ColorImage>();
            colorImage.Add(new ColorImage { ColorId = colorId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<ColorImage>>(colorImage);
        }

        private IResult CheckColorImage(int colorId)
        {
            var result = _colorImageDal.GetAll(c => c.ColorId == colorId).Count;
            if (result>0)
            {
                return new SuccessResult();

            }
            return new ErrorResult();
        }

        public IDataResult<ColorImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<ColorImage>(_colorImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, ColorImage colorImage)
        {
            colorImage.ImagePath = _fileHelper.Update(file, 
                PathConstants.ImagePath + colorImage.ImagePath, PathConstants.ImagePath);
            _colorImageDal.Update(colorImage);
            return new SuccessResult(Messages.ColorImageUpdated);
        }

     
    }
}
