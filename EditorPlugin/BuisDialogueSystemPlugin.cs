#define HYPERLENSED_BUIS_DIALOG_SYSTEM_PLUGIN

#if GODOT
using Godot;
#if TOOLS
using BuisDialogueSystem.EditorPlugin.UI;
#endif

namespace BuisDialogueSystem.EditorPlugin {
	[Tool]
    public partial class BuisDialogueSystemPlugin : Godot.EditorPlugin {
        public const string PluginName = "Buis";

        public override void _EnterTree() {
            RegisterCustomTypes();
			RegisterCustomResources();
        }
        public override void _ExitTree() {
            UnregisterCustomTypes();
			UnregisterCustomResources();
#if TOOLS
            _mainScreen.QueueFree();
#endif
        }

#region Main Screen
#if TOOLS
        private BuisDialogueSystemMainScreen _mainScreen = null;
        
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
			if (_mainScreen == null) {
                _mainScreen = new BuisDialogueSystemMainScreen();
            }

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
