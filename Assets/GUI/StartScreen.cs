using UnityEngine;
using System.Collections;

public class StartScreen : GUIFrame
{
	public static StartScreen current = null;
	
	// Use this for initialization
	void Awake ()
	{
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
				Game.StartGame();
			}
		}
	}
}
