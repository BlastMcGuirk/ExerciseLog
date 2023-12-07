using ExerciseLog.Database;

namespace ExerciseLog.Models
{
    public record class WorkoutExercise : IEntity
    {
        public int Id { get; set; } = default!;

        public int WorkoutId { get; set; } = default!;

        public int ExerciseId { get; set; } = default!;

        public int NumberInWorkout { get; set; }

        public int NumSets { get; set; }

        public Workout Workout { get; set; }
        public Exercise Exercise { get; set; }
    }
}
