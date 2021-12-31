using Godot;

public class GameCamera : Camera2D {
	[Export]
	private float _shakeTime;

	[Export]
	private float _shakeAmount;

	private Timer _timer;
	private Tween _tween;
	
	private Vector2 _defaultOffset;
	private RandomNumberGenerator _random;

	public override void _Ready() {
		_timer = GetNode<Timer>("Timer");
		_timer.WaitTime = _shakeTime;

		_tween = GetNode<Tween>("Tween");

		_defaultOffset = Offset;
		_random = new RandomNumberGenerator();

		SetProcess(false);
	}

	public override void _Process(float delta) {
		Offset = _defaultOffset + new Vector2(
			_random.RandfRange(-_shakeAmount, _shakeAmount), 
			_random.RandfRange(-_shakeAmount, _shakeAmount)
		) * delta;
	}

	public void Shake() {
		SetProcess(true);
		_timer.Start();
	}

	private void OnTimer_Timeout() {
		SetProcess(false);

		_tween.InterpolateProperty(this, "offset", Offset, _defaultOffset, 0.1f, Tween.TransitionType.Quad, Tween.EaseType.InOut);
		_tween.Start();
	}
}
