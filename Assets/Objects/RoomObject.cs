using UnityEngine;
using System.Collections;

public abstract class RoomObject : MonoBehaviour
{
	public bool friendly = true;
	public Sprite sprite = null;
	public Room room = null;

	public GUIStyle buttonStyle = new GUIStyle();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if(room == Room.currentRoom && sprite != null)
		{
			GUI.depth = 1;
			Rect rect = RoomGUI.GetRoomObjectScreenRect (Room.currentRoom, this);
			if(GUI.Button (rect, sprite.texture, buttonStyle))
			{
				OnClick ();
			}
		}
	}

	protected virtual void OnClick()
	{
	}
}
