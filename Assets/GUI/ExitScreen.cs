using UnityEngine;
using System.Collections;

public class ExitScreen : GUIFrame
{
	public static ExitScreen singleton = null;
	static GUIStyle labelStyle = new GUIStyle();

	public string message = "";

	// Use this for initialization
	void Start ()
	{
		if(singleton == null)
		{
			singleton = this;
		}
		labelStyle.alignment = TextAnchor.MiddleCenter;
		labelStyle.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show(string message = "Game ended with an unknown reason.")
	{
		this.message = message;
		this.hidden = false;
	}

	public override void OnGUI()
	{
		if(!hidden)
		{
			base.OnGUI ();
			GUI.Label(screenRect, message, labelStyle);
			if (GUI.Button (new Rect (screenRect.center.x - 50, screenRect.center.y + 50, 100, 50), "Start new game"))
			{
				Application.LoadLevel ("scene");
				Game.ShowStartScreen();
			}
		}
	}
}
