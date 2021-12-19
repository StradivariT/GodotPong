using Godot;

public class GameManager : Node2D {
	private Ball _ball;
	private Score _scoreUI;

	private Vector2 _fieldCenter;

	private int _leftScore;
	private int _rightScore;

	public override void _Ready() {
		_fieldCenter = GetViewport().GetVisibleRect().Size / 2;

		_leftScore = 0;
		_rightScore = 0;

		Node parent = GetParent();

		_scoreUI = parent.GetNode<Score>("UI/Score");
		_ball = parent.GetNode<Ball>("Ball");

		Node2D goals = parent.GetNode<Node2D>("Goals");
		foreach (Goal goal in goals.GetChildren())
			goal.Connect(nameof(Goal.GoalScored), this, nameof(OnGoal_GoalScored));
	}

	private void OnGoal_GoalScored(bool isRightGoal) {
		_scoreUI.UpdateScore(!isRightGoal, isRightGoal ? ++_leftScore : ++_rightScore);
		_ball.ResetPosition(_fieldCenter);
	}
}
