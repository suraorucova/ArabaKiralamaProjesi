using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var car in carManager.GetById(2))
            {
               Console.WriteLine(car.Description);
            }

           

            foreach (var car in carManager.GetByDailyPrice(2000,2800))
            {
                Console.WriteLine(car.Description);
            }

            Car car1 = new Car() {Id=7, BrandId=1,ColorId=2,DailyPrice=0, ModelYear=2017, Description = "2017 model BMW" };
            carManager.Add(car1);
            Console.WriteLine("-------------------------Color----------------------");

            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            foreach(var color in colorManager.GetByName("Siyah"))
            {
                Console.WriteLine(color.ColorId);
            }
            Console.WriteLine("-------------------------Brand---------------------------");
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            foreach (var brand in brandManager.GetByName("Audi"))
            {
                Console.WriteLine(brand.BrandId);
            }

            Brand brand1 = new Brand() { BrandId = 11, BrandName = "Buick" };
            brandManager.Add(brand1);
            Console.ReadLine();
        }
    }
}
      
