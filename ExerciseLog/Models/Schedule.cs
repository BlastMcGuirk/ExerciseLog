namespace ExerciseLog.Models
{
    public record class Schedule
    {
        public string Day { get; set; } = default!;

        public int? WorkoutId { get; set; }
    }
}
