using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly TestDbContext context;

        public HomeController(TestDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Restsurant>>> GetAll()
        {
            var data = await context.Restsurants.ToListAsync();

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Restsurant>> GetRestoById(int id)
        {
            var data1 = await context.Restsurants.FindAsync(id);
            if (data1 == null)
            {
                return NotFound();
            }
            return data1;
        }
        [HttpPost]
        public async Task<ActionResult<Restsurant>> Create(Restsurant rst)
        {
           await context.Restsurants.AddAsync(rst);
           await context.SaveChangesAsync();
            return Ok(rst);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Restsurant>> UpdateData(int id , Restsurant rst)
        {
            if(id != rst.Id)
            {
                return BadRequest();

            }
            context.Entry(rst).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(rst);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restsurant>> Delete(int id)
        {
            var del = await context.Restsurants.FindAsync(id);
            if (del == null) 
            {
                return NotFound();
            }
            context.Restsurants.Remove(del);
            await context.SaveChangesAsync();
            return Ok();

        }
    }

    
}
