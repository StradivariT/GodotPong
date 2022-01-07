using Godot;

public class ExitButton : Button {
	private void OnExitButton_ButtonUp() {
		GetTree().Quit();	
	}
}
