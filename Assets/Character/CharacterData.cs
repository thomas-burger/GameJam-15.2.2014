using UnityEngine;
using System.Collections;

public class CharacterData : MonoBehaviour {
	public static CharacterData singleton = null;

	public int health = 10;
	public int energy = 10;

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
}
