using Business.Abstract;
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

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length>=2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka eklendi"+":"+brand.BrandName);
            }
            else
            {
                Console.WriteLine("Marka eklenmedi");
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b => b.BrandId == id);
        }

        public List<Brand> GetByName(string name)
        {
            return _brandDal.GetAll(b => b.BrandName == name);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandId == 1)
            {
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("Marka guncellenmesi basarisiz");
            }
        }
    }
}
