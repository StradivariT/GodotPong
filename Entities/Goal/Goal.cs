using Godot;

public class Goal : Area2D {
	[Signal]
	public delegate void GoalScored();

	[Export]
	private bool _isRight;

	public override void _Ready() {}

	private void OnGoal_BodyEntered(KinematicBody2D body) {
		EmitSignal(nameof(GoalScored), _isRight);
	}
}
