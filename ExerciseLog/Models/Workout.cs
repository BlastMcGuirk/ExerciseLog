using ExerciseLog.Database;

namespace ExerciseLog.Models
{
    public record class Workout : IEntity
    {
        public int Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public List<WorkoutExercise> Exercises { get; set; } = [];
    }
}
