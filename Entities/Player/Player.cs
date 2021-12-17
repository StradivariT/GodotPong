using Godot;

public class Player : KinematicBody2D {
	[Export]
	private int _speed = 800;

	[Export]
	private bool _isRight;

	private Vector2 _velocity;

	private string _upAction;
	private string _downAction;

	public override void _Ready() {
		_velocity = Vector2.Zero;

		_upAction   = _isRight ? "upRight" : "upLeft";
		_downAction = _isRight ? "downRight" : "downLeft";
	}

	public override void _PhysicsProcess(float delta) {
		_velocity = Vector2.Zero;

		if (Input.IsActionPressed(_upAction))
			_velocity.y = -_speed;
		else if (Input.IsActionPressed(_downAction))
			_velocity.y = _speed;

		MoveAndSlide(_velocity);
	}
}
