using UnityEngine;
using System.Collections;

public enum EnemyType
{
	Spider,
	Reaper,
	Zombie
}

public class Enemy : RoomObject
{
	public EnemyType enemyType;
	public int level;

	public static string SpiderFileName = "spider";
	public static string ReaperFileName = "reaper";
	public static string ZombieFileName = "zombie";

	public static readonly int minLevel = 1;
	public static readonly int maxLevel = 10;

	// Use this for initialization
	void Start () {
		friendly = false;
		switch(enemyType)
		{
		case EnemyType.Spider:
		{
			sprite = Resources.Load<Sprite>(SpiderFileName);
			break;
		}
		case EnemyType.Reaper:
		{
			sprite = Resources.Load<Sprite>(ReaperFileName);
			break;
		}
		case EnemyType.Zombie:
		{
			sprite = Resources.Load<Sprite>(ZombieFileName);
			break;
		}
		default:
		{
			Debug.Log ("Sprite for enemy type " + enemyType + " not specified.");
			break;
		}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnClick()
	{
		CharacterData.singleton.fight (level, enemyType);
		room.RemoveObject (this);
		Destroy (this.gameObject);
	}
}
