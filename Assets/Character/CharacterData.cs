using UnityEngine;
using System.Collections;

public class CharacterData : MonoBehaviour {
	public static CharacterData singleton = null;

	public int health = 10;
	public int energy = 100;
	public int weaponlevel = 7;

	// Use this for initialization
	void Start () {
		if(singleton == null)
		{
			singleton = this;
		}

	}

	public void fight(int enemyLevel) {
		int energyDelta = 2;//enemyLevel - weaponlevel;
		int healthDelta = Mathf.Min (-energyDelta, 0); // never grow health
		energy += energyDelta;
		health += healthDelta;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
