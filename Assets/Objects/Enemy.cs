using UnityEngine;
using System.Collections;

public enum EnemyType
{
	Spider,
	Wraith,
	Zombie
}

public class Enemy : RoomObject
{
	public EnemyType enemyType;
	public int level;

	public static string SpiderFileName = "";
	public static string WraithFileName = "";
	public static string ZombieFileName = "";

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
		case EnemyType.Wraith:
		{
			sprite = Resources.Load<Sprite>(WraithFileName);
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
		room.RemoveObject (this);
		Destroy (this.gameObject);
	}
}
