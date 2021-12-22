using Godot;
using System;

public class Ball : KinematicBody2D {
	[Export]
	private int _speed = 700;

	private const float _minAngle = 0.698f; // 40 degrees in radians
	private const float _maxAngle = 0.872f; // 50 degrees in radians

	private bool _shouldMove;
	private bool _startMoving;

	private Random _random;

	private Vector2 _velocity;

	private AnimationPlayer _animationPlayer;

	public override void _Ready() {
		_random = new Random();
		
		_shouldMove = false;
		_startMoving = false;

		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _Input(InputEvent inputEvent) {
		if (!_startMoving && inputEvent.IsActionPressed("startGame"))
			_startMoving = true;
	}

	public override void _PhysicsProcess(float delta) {
		if (!_shouldMove)
			return;

		KinematicCollision2D collision = MoveAndCollide(_velocity * delta);
		if (collision == null)
			return;

		if (collision.Normal.x != 0)
			_velocity.x *= -1;
		else
			_velocity.y *= -1;
	}

	private void StartMovingIfEnabled() {
		if (!_startMoving)
			return;

		_shouldMove = true;
		_animationPlayer.Stop();
		_velocity = GetInitialVelocity(_random, _speed, _minAngle, _maxAngle);
	}

	public void ResetPosition(Vector2 position) {
		Position = position;

		_shouldMove = false;
		_startMoving = false;

		PlayAnimation("Spawn");
	}

	private int GetRandomDirection(Random random) {
		return random.NextDouble() > 0.5 ? 1 : -1;
	}

	private Vector2 GetInitialVelocity(Random random, float speed, float minAngle, float maxAngle) {
		int xDirection = GetRandomDirection(random);
		int yDirection = GetRandomDirection(random);

		float angle = ((float)random.NextDouble() * (maxAngle - minAngle)) + minAngle;

		return new Vector2(Mathf.Cos(angle) * xDirection, Mathf.Sin(angle) * yDirection) * speed;
	}

	private void PlayAnimation(string animationName) {
		_animationPlayer.Play(animationName);
	}
}
