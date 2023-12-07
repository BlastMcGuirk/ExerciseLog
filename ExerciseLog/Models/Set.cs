using ExerciseLog.Database;

namespace ExerciseLog.Models
{
    public record class Set : IEntity
    {
        public int Id { get; set; } = default!;

        public int ExerciseId { get; set; } = default!;

        public int WorkoutId { get; set; } = default!;

        public int SetNumber { get; set; }

        public int? Weight { get; set; }

        public int? LWeight { get; set; }

        public int? RWeight { get; set; }

        public int? Reps {  get; set; }

        public int? LReps {  get; set; }

        public int? RReps { get; set; }
    }
}
