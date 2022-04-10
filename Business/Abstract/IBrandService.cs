using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();

        List<Brand> GetByName(string name);
        Brand GetById(int id);

        void Update(Brand brand);

        void Add(Brand brand);
     
    }
}
