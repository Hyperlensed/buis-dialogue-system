#if GODOT && TOOLS
using Godot;

namespace BuisDialogueSystem.EditorPlugin.UI {
    public partial class BuisDialogueSystemMainScreen : Control {
        public BuisDialogueSystemMainScreen() {
			// Initialize self has Editor Plugin Main Screen
			VBoxContainer editorMainScreenContainer = EditorInterface.Singleton.GetEditorMainScreen();
		    editorMainScreenContainer.AddChild(this);
			Visible = false;

			// Initialize Main Screen Content
            Label label = new Label();

            label.Text = "DDD";

            AddChild(label);
        }
    }
}
#endif
