using Godot;

public class GameManager : Node2D {
	private Ball _ball;

	private Vector2 _fieldCenter;

	public override void _Ready() {
		_fieldCenter = GetViewport().GetVisibleRect().Size / 2;

		_ball = GetParent().GetNode<Ball>("Ball");

		Node2D goals = GetParent().GetNode<Node2D>("Goals");
		foreach (Goal goal in goals.GetChildren())
			goal.Connect(nameof(Goal.GoalScored), this, nameof(OnGoal_GoalScored));
	}

	private void OnGoal_GoalScored(bool isRight) {
		_ball.ResetPosition(_fieldCenter);
	}
}
