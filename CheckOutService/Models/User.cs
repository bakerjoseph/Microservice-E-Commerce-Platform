using System.ComponentModel.DataAnnotations;

namespace CheckOutService.Models
{
    public class User
    {
        [Key]
        public Guid userGuid { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string streetAddress { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string country { get; set; }

        [Required]
        public string zipCode { get; set; }

        [Required]
        public int cardNumber { get; set; }

        [Required]
        public DateTime expirationDate { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string cvv { get; set; }

        public List<Order>? orders { get; set; }
    }
}
