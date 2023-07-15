using System.ComponentModel.DataAnnotations;

namespace CheckOutService.Models
{
    public class UserDTO
    {
        public Guid userGuid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public int cardNumber { get; set; }
        public DateTime expirationDate { get; set; }
        public string cvv { get; set; }
    }
}
