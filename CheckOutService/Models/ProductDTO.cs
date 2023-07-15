using System.ComponentModel.DataAnnotations;

namespace CheckOutService.Models
{
    public class ProductDTO
    {
        public Guid productGuid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string dimensions { get; set; }
        public double weight { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
    }
}
