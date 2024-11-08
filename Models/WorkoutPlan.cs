namespace FitnessStudioAPI.Models
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
