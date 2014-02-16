using UnityEngine;
using System.Collections;

public class GUIFrame : MonoBehaviour
{
	public Rect frameRect;
	protected Rect screenRect;
	public bool relativeToScreenSize;
	public bool hidden = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public virtual void OnGUI()
	{
		if(!hidden)
		{
			screenRect = relativeToScreenSize ? GUIUtil.CalculateScreenRect(frameRect) : frameRect;
			GUI.Box  (screenRect, "");
		}
	}
}
