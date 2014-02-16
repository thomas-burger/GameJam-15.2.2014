using UnityEngine;
using System.Collections;

public class ExitScreen : GUIFrame
{
	public static ExitScreen singleton = null;
	static GUIStyle labelStyle = new GUIStyle();

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

	public override void OnGUI()
	{
		base.OnGUI ();
		GUI.Label(screenRect, "Game over", labelStyle);
	}
}
