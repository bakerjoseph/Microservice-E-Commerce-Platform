using System.ComponentModel.DataAnnotations;

namespace CheckOutService.Models
{
    public class Product
    {
        [Key]
        public Guid productGuid { get; set; }

        [Required]
        public Guid orderGuid { get; set; }

        [Required] 
        public Order order { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [MaxLength(4000)]
        public string description { get; set; }

        [Required]
        public string dimensions { get; set; }

        [Required]
        public double weight { get; set; }

        [Required]
        public double price { get; set; }

        [Required]
        public int amount { get; set; }
    }
}
