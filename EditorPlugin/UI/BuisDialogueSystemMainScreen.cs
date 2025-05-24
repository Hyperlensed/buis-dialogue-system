#if GODOT && TOOLS
using Godot;

namespace BuisDialogueSystem.EditorPlugin.UI {
	[Tool]
	public partial class BuisDialogueSystemMainScreen : Panel {
		private TabBar _listsTabBar;
		private TabBar _openedCharactersTabBar;
		private TabBar _openedDialoguesTabBar;

		private Panel _mainContainer;

		private Control _charactersList;
		private Control _dialoguesList;
		
		private Control _characterEdit;
		private Control _dialogueEdit;



		public override void _Ready() {
			_listsTabBar = GetNode<TabBar>("%ListsTabBar");
			_openedCharactersTabBar = GetNode<TabBar>("%OpenedCharactersTabBar");
			_openedDialoguesTabBar = GetNode<TabBar>("%OpenedDialoguesTabBar");
			
			_mainContainer = GetNode<Panel>("%MainContainer");

			_charactersList = GetNode<Control>("%CharactersList");
			_dialoguesList = GetNode<Control>("%DialoguesList");

			_characterEdit = GetNode<Control>("%CharacterEdit");
			_dialogueEdit = GetNode<Control>("%DialogueEdit");

			ListsTabBarSelected(0);
			if (_listsTabBar != null && IsInstanceValid(_listsTabBar)) {
				_listsTabBar.TabSelected += ListsTabBarSelected;
			}

			if (_openedCharactersTabBar != null && IsInstanceValid(_openedCharactersTabBar)) {
				_openedCharactersTabBar.TabSelected += OpenedCharactersTabBarSelected;
				_openedCharactersTabBar.TabClosePressed += OpenedCharactersTabBarClosed;
			}

			if (_openedDialoguesTabBar != null && IsInstanceValid(_openedDialoguesTabBar)) {
				_openedDialoguesTabBar.TabSelected += OpenedDialoguesTabBarSelected;
				_openedDialoguesTabBar.TabClosePressed += OpenedDialoguesTabBarClosed;
			}
		}



		private void ListsTabBarSelected(long tab) {
			GD.Print("ListsTabBarSelected ", tab);

			switch (tab) {
				case 0: {
					_openedCharactersTabBar.Visible = true;
					_openedDialoguesTabBar.Visible = false;

					_charactersList.Visible = true;
					_dialoguesList.Visible = false;
					_characterEdit.Visible = false;
					_dialogueEdit.Visible = false;

					break;
				}
				case 1: {
					_openedDialoguesTabBar.Visible = true;
					_openedCharactersTabBar.Visible = false;

					_charactersList.Visible = false;
					_dialoguesList.Visible = true;
					_characterEdit.Visible = false;
					_dialogueEdit.Visible = false;

					break;
				}
			}
		}



		private void OpenedCharactersTabBarSelected(long tab) {
			GD.Print("OpenedCharactersTabBarSelected ", tab);

			_charactersList.Visible = false;
			_dialoguesList.Visible = false;
			_characterEdit.Visible = true;
			_dialogueEdit.Visible = false;
		}
		private void OpenedCharactersTabBarClosed(long tab) {
			GD.Print("OpenedCharactersTabBarClosed ", tab);
		}



		private void OpenedDialoguesTabBarSelected(long tab) {
			GD.Print("OpenedDialoguesTabBarSelected ", tab);

			_charactersList.Visible = false;
			_dialoguesList.Visible = false;
			_characterEdit.Visible = false;
			_dialogueEdit.Visible = true;
		}
		private void OpenedDialoguesTabBarClosed(long tab) {
			GD.Print("OpenedDialoguesTabBarClosed ", tab);
		}
    }
}
#endif
