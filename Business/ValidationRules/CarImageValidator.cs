using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ci => ci.ImagePath).NotEmpty();
        }
        
    }
}
