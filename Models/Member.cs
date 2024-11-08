namespace FitnessStudioAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; }
    }
}
