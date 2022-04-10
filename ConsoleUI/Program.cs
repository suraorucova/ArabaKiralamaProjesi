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
            //CarTest();
            ColorTest();
            //BrandTest();

            Console.ReadLine();
        }

        private static void BrandTest()
        {
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
            brandManager.Update(brand1);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            foreach (var color in colorManager.GetByName("Siyah"))
            {
                Console.WriteLine(color.ColorId);
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine(car.Description);
            }



            foreach (var car in carManager.GetByDailyPrice(2000, 2800))
            {
                Console.WriteLine(car.Description);
            }

            Car car1 = new Car() { Id = 7, BrandId = 1, ColorId = 2, DailyPrice = 0, ModelYear = 2017, Description = "2017 model BMW" };
            carManager.Add(car1);
            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id+"/"+car.Description+
                    "/"+car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice);
            }
        }
    }
}
      
