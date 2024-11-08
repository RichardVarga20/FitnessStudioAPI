using Microsoft.EntityFrameworkCore;
using FitnessStudioAPI.Models;

namespace FitnessStudioAPI.Data
{
    public class FitnessStudioContext : DbContext
    {
        public FitnessStudioContext(DbContextOptions<FitnessStudioContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
    }
}
