#define HYPERLENSED_BUIS_DIALOG_SYSTEM_PLUGIN

#if GODOT
using Godot;
#if TOOLS
using BuisDialogueSystem.EditorPlugin.UI;
#endif

namespace BuisDialogueSystem.EditorPlugin {
	[Tool]
    public partial class BuisDialogueSystemPlugin : Godot.EditorPlugin {
        public const string PluginName = "Dialogues";

        public override void _EnterTree() {
            RegisterCustomTypes();
			RegisterCustomResources();
#if TOOLS
			InitializeMainScreen();
#endif
        }
        public override void _ExitTree() {
            UnregisterCustomTypes();
			UnregisterCustomResources();
#if TOOLS
            _mainScreen?.Free();
			_mainScreen = null;
#endif
        }

#region Main Screen
#if TOOLS
        private BuisDialogueSystemMainScreen _mainScreen = null;
        
		private void InitializeMainScreen() {
			// Initialize self has Editor Plugin Main Screen
			VBoxContainer editorMainScreenContainer = EditorInterface.Singleton.GetEditorMainScreen();

			PackedScene buisDialogueSystemMainScreenPackedScene = ResourceLoader.Load<PackedScene>(
                ((Resource)GetScript()).ResourcePath.GetBaseDir() + "/UI/BuisDialogueSystemMainScreen.tscn",
                "PackedScene"
            );
			_mainScreen = buisDialogueSystemMainScreenPackedScene.Instantiate<BuisDialogueSystemMainScreen>();
			editorMainScreenContainer.AddChild(_mainScreen);

			_MakeVisible(false);
		}
        public override string _GetPluginName() {
            return PluginName;
        }
        public override Texture2D _GetPluginIcon() {
            Texture2D pluginIcon = ResourceLoader.Load<Texture2D>(
                ((Resource)GetScript()).ResourcePath.GetBaseDir() + "/UI/Icon.svg",
                "Texture2D"
            );
            
            return pluginIcon;
        }
        public override bool _HasMainScreen() {
		    return true;
	    }
        public override void _MakeVisible(bool visible) {
			_mainScreen.Visible = visible;
        }
#endif
#endregion

#region Custom Types
        private void RegisterCustomTypes() {

        }
        private void UnregisterCustomTypes() {

        }
#endregion

#region Custom Types
        private void RegisterCustomResources() {

        }
        private void UnregisterCustomResources() {

        }
#endregion

    }
}
#endif
