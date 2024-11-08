using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessStudioAPI.Data;
using FitnessStudioAPI.Models;

namespace FitnessStudioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly FitnessStudioContext _context;

        public WorkoutPlansController(FitnessStudioContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutPlan>>> GetWorkoutPlans()
        {
            return await _context.WorkoutPlans.Include(wp => wp.Member).Include(wp => wp.Trainer).ToListAsync();
        }

        // GET: api/WorkoutPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutPlan>> GetWorkoutPlan(int id)
        {
            var workoutPlan = await _context.WorkoutPlans.FindAsync(id);

            if (workoutPlan == null)
            {
                return NotFound();
            }

            return workoutPlan;
        }

        // POST: api/WorkoutPlans
        [HttpPost]
        public async Task<ActionResult<WorkoutPlan>> PostWorkoutPlan(WorkoutPlan workoutPlan)
        {
            _context.WorkoutPlans.Add(workoutPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutPlan", new { id = workoutPlan.Id }, workoutPlan);
        }

        // PUT: api/WorkoutPlans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutPlan(int id, WorkoutPlan workoutPlan)
        {
            if (id != workoutPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(workoutPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/WorkoutPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutPlan(int id)
        {
            var workoutPlan = await _context.WorkoutPlans.FindAsync(id);
            if (workoutPlan == null)
            {
                return NotFound();
            }

            _context.WorkoutPlans.Remove(workoutPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
