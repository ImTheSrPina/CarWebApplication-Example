namespace CarWebApplication.Models
{
    public class CreateCar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }
        public double TopSpeed { get; set; }
        public double Acceleration { get; set; }
        public string Transmission { get; set; }

        public string OriginCountry { get; set; }
        public int Year { get; set; }

    }
}
