using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sample_database.Context;
using sample_database.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sample_database.Controllers
{
    [Route("api/[controller]")]
    public class DaysController : Controller
    {
        private DaysContext _context;

        public DaysController(DaysContext days)
        {
            _context = days;
        }

        // GET: api/Days
        [HttpGet]
        public IEnumerable<Days> Get()
        {
            return _context.Days;
        }

        // GET api/Days/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDays([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var days = await _context.Days.FindAsync(id);

            if (days == null)
            {
                return NotFound();
            }

            return Ok(days);
        }

        [HttpPost]
        public async Task<ActionResult> AddDay(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var lastId = _context.Days.LastOrDefault().Id + 1;
            var d = new Days
            {
                Id = lastId,
                DayName = name
            };
            _context.Add(d);
            await _context.SaveChangesAsync();
            return Ok(d);
        }

    }
}
