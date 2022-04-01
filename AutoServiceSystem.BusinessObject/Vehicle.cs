namespace AutoServiceSystem.BusinessObject
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string RegistrationPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Client Client { get; set; }
    }
}
