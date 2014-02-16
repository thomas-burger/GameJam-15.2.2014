using UnityEngine;
using System.Collections;

public class StartScreen : GUIFrame
{
		public static StartScreen current = null;
		private GUIStyle titleStyle = new GUIStyle ();
		string randomSeedString = "Insert random seed";
	
		// Use this for initialization
		void Awake ()
		{
				if (current == null) {
						current = this;
				}
				titleStyle.fontSize = 20;
				titleStyle.alignment = TextAnchor.MiddleCenter;
				titleStyle.normal.textColor = Color.white;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKey ("escape")) {
						Application.Quit ();
				}

		}

		public override void Hide ()
		{
				base.Hide ();
				CharacterSelectionScreen.singleton.Hide ();
		}
	
		public override void OnGUI ()
		{
				if (!hidden) {
						base.OnGUI ();
						float width = screenRect.width;
						float height = screenRect.height;
						//title
						GUI.Label (new Rect (screenRect.x, screenRect.y, width, 0.2f * height), "GameJam(15.2.2014)", titleStyle);
						//Input field for random seed
						randomSeedString = GUI.TextField (new Rect (screenRect.center.x - 100, screenRect.y + 100, 200, 25), randomSeedString);
						//character selection screen
						CharacterSelectionScreen.singleton.Show (new Rect (screenRect.x, screenRect.y + 200, screenRect.width, screenRect.height - 200));
						//new game button
						if (GUI.Button (new Rect (screenRect.center.x - 105, screenRect.y + 150, 100, 50), "Start game")) {
								Game.StartGame (randomSeedString.GetHashCode ());
						}
						if (GUI.Button (new Rect (screenRect.center.x + 5, screenRect.y + 150, 100, 50), "Quit game")) {
								Application.Quit ();
						}
				}
		}
}
