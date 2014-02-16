using UnityEngine;
using System.Collections;

public class CharacterData : MonoBehaviour {
	public static CharacterData singleton = null;

	private int energy = 101;
	private int weaponLevel = 5;
	private int weaponType = 0;
	private int health= 10;

	// Use this for initialization
	void Start () {
		if(singleton == null)
		{
			singleton = this;
		}

	}
	public int getHealth(){
		return health;
	}
	public int getEnergy(){
		return energy;
	}
	public int getWeaponLevel(){ 
		return weaponLevel;
	}
	public int getWeaponType(){ 
		return weaponType;
	}
	public void fight(int enemyLevel) {
		int weaponDelta;
		if (weaponType == 0) {
				}
		int energyDelta = enemyLevel - weaponLevel;
		int healthDelta = Mathf.Min (-energyDelta, 0); // never gain health
		energy += energyDelta;
		health += healthDelta;
		checkForDeath ();
	}

	void checkForDeath ()
	{
		if (energy <= 0 || health <= 0) {
			ExitScreen.singleton.Hide ();
		}
	}
	public void oneStep(){
		updateEnergy (-weaponLevel);
	}
	public void updateEnergy(int delta){
		energy += delta;
		checkForDeath ();
	}
	public void updateHealth(int delta){
		health += delta;
		checkForDeath ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
