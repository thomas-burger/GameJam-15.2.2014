using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RoomObjectType
{
	Enemy,
	Door,
	Exit
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
		CharacterData.singleton.energy--;
		if (CharacterData.singleton.energy <= 0) {
			ExitScreen.singleton.hidden = false;
		}
		currentRoom = targetRoom;
		Floor.currentFloor = targetRoom.floor;
	}

	public static bool EnemiesInCurrentRoom()
	{
		foreach(RoomObject roomObject in currentRoom.objects)
		{
			if(!roomObject.friendly)
			{
				Debug.Log ("enemyObject");
				return true;
			}
		}
		return false;
	}

	public static RoomObject CreateObject(RoomObjectType type, Vector2 position, Sprite sprite, Room room = null)
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

	public static Door CreateDoor(Vector2 position, Sprite sprite, Room source, Room target)
	{
		Door door = Room.CreateObject (RoomObjectType.Door, position, sprite, source) as Door;
		door.targetRoom = target;
		return door;
	}
}
