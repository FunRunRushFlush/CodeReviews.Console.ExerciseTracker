namespace ExerciseTracker.App.Model;

public class Excercise : Entity
{
    public string ExerciseName { get; set; }
    public DateTime ExerciseStart { get; set; }
    public DateTime ExerciseEnd { get; set; }
    public TimeSpan ExerciseDuration { get; set; }
    public string Comments { get; set; }
}