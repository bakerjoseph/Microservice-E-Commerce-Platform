namespace CheckOutService.Models
{
    public class OrderDTO
    {
        public UserDTO user { get; set; }
        public Guid basketGuid { get; set; }
        public bool readBasket { get; set; }
        public List<ProductDTO>? products { get; set; }
    }
}
