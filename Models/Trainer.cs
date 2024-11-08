namespace FitnessStudioAPI.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; }
    }
}
