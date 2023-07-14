using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountServiceDBContext _db;

        public AccountController(AccountServiceDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(User user)
        {
            try
            {
                user.UserGuid = Guid.NewGuid();
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "User Account created",
                    UserGuid = user.UserGuid
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                List<User> users = await _db.Users.ToListAsync();
                bool found = false;
                foreach (User u in users)
                {
                    if (u.Username == user.Username && u.Password == user.Password)
                    {
                        found = true;
                        break;
                    }
                }
                return Ok(new
                {
                    Success = true,
                    Message = "Attempted login",
                    LoginSuccess = found
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{AccountGuid}")]
        public async Task<ActionResult<User>> GetAccount(Guid accountGuid)
        {
            try
            {
                User? user = await _db.Users.FindAsync(accountGuid);
                if (user == null)
                    throw new Exception($"User with {nameof(accountGuid)} {accountGuid} not found");
                return Ok(new
                {
                    Success = true,
                    Message = "User Account found",
                    FoundUser = user
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<List<User>>> GetAllAcounts()
        {
            try
            {
                List<User> users = await _db.Users.ToListAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "All User Accounts have been returned",
                    users
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{AccountGuid}")]
        public async Task<IActionResult> UpdateAccount(Guid accountGuid, User user)
        {
            try
            {
                if (user.UserGuid != accountGuid)
                    throw new Exception($"Path parameter {nameof(accountGuid)} does not match {nameof(user.UserGuid)}");
                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "User Account updated",
                    UserGuid = user.UserGuid
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{AccountGuid}")]
        public async Task<IActionResult> DeleteAccount(Guid accountGuid)
        {
            try
            {
                User? user = await _db.Users.FindAsync(accountGuid);
                if (user == null)
                    throw new Exception($"User with {nameof(accountGuid)} {accountGuid} not found");
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Message = "User Account deleted"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
