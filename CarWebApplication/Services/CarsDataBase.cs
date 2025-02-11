using System;
using CarWebApplication.Models;

namespace CarWebApplication.Services
{
    public class CarsDataBase
    {
        public static List<Car> Cars { get; set; } = new List<Car>()
        {
            new Car(
                1,
                "Porsche",
                "Carrera GT",
                "Convertible",
                334,
                3.5,
                "Six-speed manual transmission",
                "Germany",
                2003
            ),
            new Car(
                2,
                "Lamborghini",
                "Huracán Evo Spyder",
                "Spyder",
                325,
                3.1,
                "7 speed dual clutch automatic",
                "Italy",
                2019
            ),
            new Car(
                3,
                "McLaren",
                "Senna",
                "Coupe",
                340,
                2.6,
                "7-speed daul clutch",
                "United Kingdom",
                2018
            ),
        };

        public static List<Car> GetCars()
        {
            return Cars;
        }

        public static Car? LastCar()
        {
            int LastCarId = Cars.Max(element => element.Id);

            return Cars.FirstOrDefault(element => element.Id == LastCarId);
        }

        public static Car? FindById(int Id)
        {
            return Cars.FirstOrDefault(element => element.Id == Id);
        }

        public static int AddCar(CreateCar car)
        {
            int LastCarId = Cars.Max(element => element.Id);
            Car newCar = new Car(
                LastCarId + 1,
                car.Brand,
                car.Model,
                car.CarType,
                car.TopSpeed,
                car.Acceleration,
                car.Transmission,
                car.OriginCountry,
                car.Year
            );
            Cars.Add(newCar);
            return newCar.Id;
        }

        public static bool DeleteCar(int id)
        {
            Car? car = Cars.FirstOrDefault(element => element.Id == id);

            if (car == null)
            {
                return false;
            }
            else
            {
                Cars.Remove(car);
                return true;
            }
        }

        public static bool UpdateCar(int id, CreateCar car)
        {
            Car? carToUpdate = Cars.FirstOrDefault(element => element.Id == id);
            if (carToUpdate == null)
            {
                return false;
            }
            else
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.CarType = car.CarType;
                carToUpdate.TopSpeed = car.TopSpeed;
                carToUpdate.Acceleration = car.Acceleration;
                carToUpdate.Transmission = car.Transmission;
                carToUpdate.OriginCountry = car.OriginCountry;
                carToUpdate.Year = car.Year;
                return true;
            }
        }
    }
}
