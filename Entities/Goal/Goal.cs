using Godot;

public class Goal : Area2D {
	[Signal]
	public delegate void GoalScored();

	[Export]
	private bool _isRight;

	private Particles2D _particles2D;

	public override void _Ready() {
		_particles2D = GetNode<Particles2D>("Particles2D");
	}

	private void OnGoal_BodyEntered(KinematicBody2D body) {
		_particles2D.GlobalPosition = body.Position;
		_particles2D.Restart();

		EmitSignal(nameof(GoalScored), _isRight);
	}
}
