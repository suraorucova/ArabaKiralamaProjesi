using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded+":"+brand.BrandName);
            
            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        public IDataResult<List<Brand>> GetByName(string name)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandName == name));
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandId == 1)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            return new ErrorResult(Messages.BrandUpdatedInvalid);
        }
    }
}
