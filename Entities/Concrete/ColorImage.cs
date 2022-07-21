using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ColorImage:IEntity
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
