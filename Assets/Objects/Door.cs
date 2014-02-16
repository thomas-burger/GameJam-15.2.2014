using UnityEngine;
using System.Collections;

public class Door : RoomObject {
	public Room targetRoom = null;

	// Use this for initialization
	void Start () {
		friendly = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnClick()
	{
		if(!Room.EnemiesInCurrentRoom())
		{
			Room.GoToRoom (targetRoom);
		}
		else
		{
			Debug.Log ("Cannot go through door if enemy is in room.");
		}
	}
}
