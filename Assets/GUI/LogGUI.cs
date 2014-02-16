using UnityEngine;
using System.Collections;

public class LogGUI : GUIFrame {
	public static LogGUI singleton = null;

	// Use this for initialization
	void Start () {
		if(singleton == null)
		{
			singleton = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnGUI()
	{
		if(!hidden)
		{
			base.OnGUI();
			GUI.Label(screenRect, "Text");
		}
	}
}
