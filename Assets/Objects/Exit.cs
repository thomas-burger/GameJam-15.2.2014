using UnityEngine;
using System.Collections;

public class Exit : RoomObject {
	
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
			Game.EndGame ("You reached the exit.");
		}
		else
		{
			Debug.Log ("Cannot go through exit if enemy is in room.");
		}
	}
}
