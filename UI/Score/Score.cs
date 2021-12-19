using Godot;

public class Score : Control {
	private Label _scoreLeft;
	private Label _scoreRight;

	public override void _Ready() {
		_scoreLeft = GetNode<Label>("HBoxContainer/ScoreLeft");
		_scoreRight = GetNode<Label>("HBoxContainer/ScoreRight");
	}

	public void UpdateScore(bool updateRightScore, int score) {
		if (updateRightScore)
			_scoreRight.Text = score.ToString();
		else
			_scoreLeft.Text = score.ToString();
	}
}
