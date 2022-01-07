using Godot;

public class ChangeSceneButton : Button {
	[Export(PropertyHint.File, "*.tscn")]
	private string _nextScenePath;

	private void OnChangeSceneButton_ButtonUp() {
		GetTree().ChangeScene(_nextScenePath);
	}
}
