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
            var result = brandManager.GetAll();
            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }

            var result2 = brandManager.GetByName("Audi");
            if (result2.Success==true)
            {
                foreach (var brand in result2.Data)
                {
                    Console.WriteLine(brand.BrandId);
                }
            }
          
            

            Brand brand1 = new Brand() { BrandId = 11, BrandName = "Buick" };
            var result3 = brandManager.Add(brand1);
            if (result3.Success==true)
            {
                Console.WriteLine(result3.Message);
            }

            var result4 = brandManager.Update(brand1);
            if (result4.Success==true)
            {
                Console.WriteLine(result4.Message);
            }
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            var result = colorManager.GetAll();
            if (result.Success==true)
            {
               foreach (var color in result.Data)
               {
                   Console.WriteLine(color.ColorName);
                }
            }

            var result2 = colorManager.GetByName("Siyah");
            if (result2.Success==true)
            {
               foreach (var color in result2.Data)
               {
                   Console.WriteLine(color.ColorId);
               }
            }

           
            
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetById(4);
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                   Console.WriteLine(car.Description);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }

            var result2 = carManager.GetByDailyPrice(2000,3000);
            if (result2.Success == true)
            {
                foreach (var car in result2.Data)
                {
                   Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }

            var result3 = carManager.GetAll();
            if (result3.Success==true)
            {
                foreach (var car in result3.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            var result4 = carManager.GetCarDetails();
            if (result4.Success==true)
            {
                foreach (var car in result4.Data)
                {
                    Console.WriteLine(car.Id + "/" + car.Description +
                        "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
               Console.WriteLine(result4.Message);
            }
            Car car1 = new Car() { Id = 7, BrandId = 1, ColorId = 2, DailyPrice = 0, ModelYear = 2017, Description = "2017 model BMW" };
            var result5 = carManager.Add(car1);
            if (result5.Success==true)
            {
                Console.WriteLine(result5.Message);
            }
            
            var result6= carManager.Delete(car1);
            if (result6.Success==true)
            {
                Console.WriteLine(result6.Message);
            }

            
           
        }
    }
}
      
