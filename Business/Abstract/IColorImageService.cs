using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorImageService
    {
        IResult Add(IFormFile file, ColorImage colorImage);
        IResult Delete(ColorImage colorImage);
        IResult Update(IFormFile file,ColorImage colorImage);
        IDataResult<List<ColorImage>> GetAll();
        IDataResult<List<ColorImage>> GetByColorId( int colorId);
        IDataResult<ColorImage>GetByImageId(int imageId);
    }
}
