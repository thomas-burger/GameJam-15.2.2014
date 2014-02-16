using UnityEngine;
using System.Collections;

public enum CharacterClass
{
	Warrior,
	Wizard,
	Thief
}

public class CharacterData : MonoBehaviour {
	public static CharacterData singleton = null;

	
	private CharacterClass characterClass;
	private int energy = 101;
	private int weaponLevel = 5;
	private WeaponType weaponType = WeaponType.BARE_HANDS;
	private int health= 10;

	// Use this for initialization
	void Start () {
		if(singleton == null)
		{
			singleton = this;
		}

	}
	public CharacterClass GetClass()
	{
		return characterClass;
	}
	public void SetClass(CharacterClass characterClass)
	{
		this.characterClass = characterClass;
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
	public WeaponType getWeaponType(){ 
		return weaponType;
	}
	public void fight(int enemyLevel, EnemyType enemyType) {
		int weaponDelta = Combat.getModifier(weaponType, enemyType);

		int energyDelta = enemyLevel - (weaponLevel + weaponDelta);
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
		energy = Mathf.Min (100, energy);
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
