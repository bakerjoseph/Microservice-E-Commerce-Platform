using System.ComponentModel.DataAnnotations;

namespace CheckOutService.Models
{
    public class Order
    {
        [Key]
        public Guid orderGuid { get; set; }

        [Required]
        public Guid userGuid { get; set; }

        [Required]
        public Guid basketGuid { get; set; }

        [Required]
        public User user { get; set; }

        [Required]
        public DateTime placedDate { get; set; }

        [Required]
        public List<Product>? products { get; set; }
    }
}
