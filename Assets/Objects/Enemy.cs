using UnityEngine;
using System.Collections;

public class Enemy : RoomObject {

	// Use this for initialization
	void Start () {
		friendly = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnClick()
	{
		room.RemoveObject (this);
		Destroy (this.gameObject);
	}
}
