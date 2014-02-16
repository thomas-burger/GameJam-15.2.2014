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
			int score = CharacterData.singleton.getHealth()*10+CharacterData.singleton.getEnergy();
			Game.EndGame ("You reached the exit. Score: "+score);
		}
		else
		{
			Debug.Log ("Cannot go through exit if enemy is in room.");
		}
	}
}
