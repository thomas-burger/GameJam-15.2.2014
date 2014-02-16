using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RoomObjectType
{
	Enemy,
	Door,
	Exit,
	Decor
}

public class Room {
	public static Room currentRoom = null;

	public string roomName = "";
	public List<RoomObject> objects = new List<RoomObject>();
	public Sprite roomSprite = null;

	public Floor floor = null;

	public void RemoveObject(RoomObject obj)
	{
		objects.Remove (obj);
	}

	public static Room CreateRoom(Sprite roomSprite, string roomName)
	{
		Room room = new Room ();
		room.roomSprite = roomSprite;
		room.roomName = roomName;
		return room;
	}

	public static void GoToRoom(Room targetRoom)
	{
		CharacterData.singleton.oneStep ();
		currentRoom = targetRoom;
		Floor.currentFloor = targetRoom.floor;
	}

	public static bool EnemiesInCurrentRoom()
	{
		foreach(RoomObject roomObject in currentRoom.objects)
		{
			if(!roomObject.friendly)
			{
				return true;
			}
		}
		return false;
	}
	public static Enemy getEnemy(){
		foreach (RoomObject roomObject in currentRoom.objects) {
			if (!roomObject.friendly) {
				return (Enemy)roomObject;
			}
		}
		return null;
	}
	private static RoomObject CreateObject(RoomObjectType type, Vector2 position, Sprite sprite, Room room)
	{
		if(room == null)
		{
			room = currentRoom;
		}
		GameObject go = new GameObject (type.ToString ());
		go.transform.position = new Vector3 (position.x, position.y, 0);
		RoomObject roomObject = null;
		switch (type)
		{
		case RoomObjectType.Enemy:
		{
			roomObject = go.AddComponent<Enemy>();
			break;
		}
		case RoomObjectType.Door:
		{
			roomObject = go.AddComponent<Door>();
			break;
		}
		case RoomObjectType.Exit:
		{
			roomObject = go.AddComponent<Exit>();
			break;
		}
		case RoomObjectType.Decor:
		{
			roomObject = go.AddComponent<Decor>();
			break;
		}
		default:
		{
			Debug.Log ("Error: Creating " + type + " in room not implemented");
			return null;
		}
		}
		roomObject.sprite = sprite;
		if (roomObject != null)
		{
			room.objects.Add (roomObject);
		}
		roomObject.room = room;
		return roomObject;
	}

	public static Exit CreateExit(Vector2 position, Sprite sprite, Room room)
	{
		Exit exit = Room.CreateObject (RoomObjectType.Exit, position, sprite, room) as Exit;
		return exit;
	}

	public static Door CreateDoor(Vector2 position, Sprite sprite, Room source, Room target)
	{
		Door door = Room.CreateObject (RoomObjectType.Door, position, sprite, source) as Door;
		door.targetRoom = target;
		return door;
	}

	public static Enemy CreateEnemy(Vector2 position, EnemyType type, int level, Room room)
	{
		Enemy enemy = Room.CreateObject (RoomObjectType.Enemy, position, null, room) as Enemy;
		enemy.enemyType = type;
		enemy.level = level;
		return enemy;
	}

	public static Decor CreateDecor(Vector2 position, DecorType type, Room room)
	{
		Decor decor = Room.CreateObject (RoomObjectType.Decor, position, null, room) as Decor;
		decor.decorType = type;
		return decor;
	}

	public static Enemy CreateRandomEnemy(Vector2 position, int percentChance, Room room )
	{
		bool createEnemy = (Random.Range(0, 100) < percentChance);
		if(createEnemy)
		{
			int numEnemyTypes = System.Enum.GetValues (typeof(EnemyType)).Length;
			int rndEnemyType = Random.Range (0, numEnemyTypes);
			int rndEnemyLevel = Random.Range (Enemy.minLevel, Enemy.maxLevel);
			return CreateEnemy (position, (EnemyType)rndEnemyType, rndEnemyLevel, room);
		}
		else
		{
			return null;
		}
	}

	public static List<Decor> CreateRandomDecors(Vector2 position, int percentChance, Room room )
	{
		List<Decor> decors = new List<Decor>();
		List<Vector2> positions = new List<Vector2>();
		positions.Add (new Vector2 (-240,40)); // table
		positions.Add (new Vector2 (-200,-180)); // left candle 1
		positions.Add (new Vector2 (-350,-100)); // left candle 2
		positions.Add (new Vector2 (0,300)); // barrel
		positions.Add (new Vector2 (100,-230)); // right candle
		positions.Add (new Vector2 (400,-50)); // banner
		positions.Add (new Vector2 (80,100)); // rug
		for(int i=0; i<System.Enum.GetValues (typeof(DecorType)).Length; i++)
		{
			bool createDecor = (Random.Range(0, 100) < percentChance);
			if(createDecor)
			{
				Decor decor = CreateDecor (positions[i], (DecorType)i, room);
				decors.Add(decor);
			}
		}
		//return CreateDecor (position, (DecorType)2, room);
		return decors;
	}
}
