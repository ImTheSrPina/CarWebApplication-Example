namespace CarWebApplication.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }
        public double TopSpeed { get; set; }
        public double Acceleration { get; set; }
        public string Transmission { get; set; }

        public string OriginCountry { get; set; }
        public int Year { get; set; }

        public Car(int id, string brand, string model, string carType, double topSpeed, double acceleration, string transmission, string originCountry, int year)
        {
            Id = id;
            Brand = brand;
            Model = model;
            CarType = carType;
            TopSpeed = topSpeed;
            Acceleration = acceleration;
            Transmission = transmission;
            OriginCountry = originCountry;
            Year = year;
        }
    }
}
