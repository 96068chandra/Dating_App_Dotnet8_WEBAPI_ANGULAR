using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {


            var users=await _context.Users.ToListAsync();
            return Ok(users);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var user= await _context.Users.FirstOrDefaultAsync(p =>p.Id==id);
            if(user == null)  return NotFound(); 
            return Ok(user);
        }


    }
}
