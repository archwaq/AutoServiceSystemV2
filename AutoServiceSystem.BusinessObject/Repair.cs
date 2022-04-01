namespace AutoServiceSystem.BusinessObject
{
    public class Repair
    {
        public int Id { get; set; }
        public System.DateTime CreatedDate { get; set; } = System.DateTime.Now;
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
