using AutoMapper;

namespace CheckOutService.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
