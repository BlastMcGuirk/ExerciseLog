using ExerciseLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseLog.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "exercise_log.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>()
                .ToTable("Schedule")
                .HasKey(s => s.Day);

            modelBuilder.Entity<Workout>()
                .ToTable("Workouts")
                .HasKey(w => w.Id);
            modelBuilder.Entity<Workout>()
                .Property(s => s.Id)
                    .ValueGeneratedOnAdd();
            modelBuilder.Entity<Workout>()
                .Navigation(w => w.Exercises)
                    .AutoInclude();

            modelBuilder.Entity<WorkoutExercise>()
                .ToTable("WorkoutExercises")
                .HasKey(we => we.Id);
            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(we => we.WorkoutId);
            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany()
                .HasForeignKey(we => we.ExerciseId);

            modelBuilder.Entity<Exercise>()
                .ToTable("Exercises")
                .HasKey(e => e.Id);
            modelBuilder.Entity<Exercise>()
                .Property(e => e.Id)
                    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Set>()
                .ToTable("Sets");
        }
    }
}
