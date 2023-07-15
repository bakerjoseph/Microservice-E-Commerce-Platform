using AutoMapper;
using CheckOutService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckOutService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly CheckOutServiceDBContext _db;
        private readonly IMapper _mapper;

        public CheckOutController(CheckOutServiceDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO order)
        {
            try
            {
                Order fullOrder = _mapper.Map<Order>(order);
                fullOrder.orderGuid = Guid.NewGuid();
                fullOrder.placedDate = DateTime.Now;
                // Check if we need to read from a basket
                _db.Orders.Add(fullOrder);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "Order Created Successfully",
                    UserGuid = fullOrder.userGuid
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("AllPreviousUserOrders/{userGuid}")]
        public async Task<IActionResult> GetOrdersByUserGuid(Guid userGuid)
        {
            try
            {
                List<Order> orders = await _db.Orders.Include(o => o.products).Include(o => o.user).Where(x => x.userGuid == userGuid).ToListAsync();
                return Ok(new
                {
                    Success = true,
                    Message = $"Orders Retrieved Successfully for User: {userGuid}",
                    Orders = orders
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{orderGuid}")]
        public async Task<IActionResult> GetOrderByOrderGuid(Guid orderGuid)
        {
            try
            {
                Order? order = await _db.Orders.Include(o => o.products).Include(o => o.user).Where(x => x.orderGuid == orderGuid).FirstOrDefaultAsync();
                return Ok(new
                {
                    Success = true,
                    Message = $"Order Retrieved Successfully for Order: {orderGuid}",
                    Order = order
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("AllPreviousOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                List<Order> orders = await _db.Orders.Include(o => o.products).Include(o => o.user).ToListAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "Orders Retrieved Successfully",
                    Orders = orders
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{orderGuid}")]
        public async Task<IActionResult> UpdateOrder(Guid orderGuid, OrderDTO order)
        {
            try
            {
                Order fullOrder = _mapper.Map<Order>(order);
                _db.Orders.Update(fullOrder);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "Order Updated Successfully",
                    Order = fullOrder
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{orderGuid}")]
        public async Task<IActionResult> DeleteOrder(Guid orderGuid)
        {
            try
            {
                if (await _db.Orders.Include(o => o.products).Where(o => o.orderGuid == orderGuid).FirstOrDefaultAsync() is Order order)
                {
                    // Remove all products from order
                    foreach (Product product in order.products)
                    {
                        _db.Products.Remove(product);
                    }
                    await _db.SaveChangesAsync();
                    // Remove the order
                    _db.Orders.Remove(order);
                    await _db.SaveChangesAsync();
                    return Ok(new
                    {
                        Success = true,
                        Message = "Order Deleted Successfully",
                    });
                }
                else
                {
                    return Ok("Nothing to delete");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
