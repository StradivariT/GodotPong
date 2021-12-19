using Godot;
using System;

public class Ball : KinematicBody2D {
	[Export]
	private int _speed = 700;

	private const float _minAngle = 0.698f; // 40 degrees in radians
	private const float _maxAngle = 0.872f; // 50 degrees in radians

	private Random _random;
	private bool _shouldMove;

	private Vector2 _velocity;

	public override void _Ready() {
		_random = new Random();
		_shouldMove = false;
	}

	public override void _Input(InputEvent inputEvent) {
		if (!_shouldMove && inputEvent.IsActionPressed("startGame")) {
			_velocity = GetInitialVelocity(_random, _speed, _minAngle, _maxAngle);
			_shouldMove = true;
		}
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

	public void ResetPosition(Vector2 position) {
		Position = position;
		_shouldMove = false;
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
}
