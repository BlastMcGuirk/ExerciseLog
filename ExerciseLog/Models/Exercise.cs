using ExerciseLog.Database;

namespace ExerciseLog.Models
{
    public record class Exercise : IEntity
    {
        public int Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string? Notes { get; set; }

        public string? ImageURL { get; set; }

        public string? VideoURL { get; set; }

        public bool TwoWeights { get; set; }

        public bool TwoSides { get; set; }
    }
}
