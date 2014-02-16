using UnityEngine;
using System.Collections;

public class StartScreen : GUIFrame
{
	public static StartScreen current = null;
	public static int randomSeed = 0;
	
	// Use this for initialization
	void Start ()
	{
		hidden = false;
		if(current == null)
		{
			current = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void OnGUI()
	{
		if(!hidden)
		{
			base.OnGUI ();
			if(GUI.Button(new Rect(screenRect.center.x-50, screenRect.center.y-50, 100, 100), "Start game"))
			{
				Debug.Log ("Start game");
				hidden = true;
				Init.current.InitDungeon(randomSeed);
				InventoryGUI.singleton.hidden = false;
				LogGUI.singleton.hidden = false;
				RoomGUI.singleton.hidden = false;
			}
		}
	}
}
