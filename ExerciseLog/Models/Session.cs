namespace ExerciseLog.Models
{
    public class Session
    {
        public int Id { get; set; }

        public DateTime SessionDate { get; set; }

        public Workout Workout { get; set; }

        public List<Set> Sets { get; set; }
    }
}
