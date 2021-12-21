using Godot;
using System;

public class StartGamePrompt : Control {
	private bool _fadedOut;

	private AnimationPlayer _animationPlayer;

	public override void _Ready() {
		_fadedOut = false;

		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _Input(InputEvent inputEvent) {
		if (!_fadedOut && inputEvent.IsActionPressed("startGame")) {
			_animationPlayer.Play("FadeOut");
			_fadedOut = true;
		}
	}
}
