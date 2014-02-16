using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Init : MonoBehaviour {

	public Sprite roomSprite = null;
	public Sprite doorSprite = null;
	public Sprite ladderSprite = null;
	public Sprite exitSprite = null;

	public static Init current = null;

	public static readonly int numRoomsPerFloor = 10;
	public static readonly int numFloors = 10;

	// Use this for initialization
	void Start () {
		current = this;
	}

	public void InitDungeon(int seed)
	{
		Random.seed = seed;
		for(int floorNum = 0; floorNum < numFloors; floorNum++)
		{
			List<Room> rooms = new List<Room>();
			for(int i=0; i<numRoomsPerFloor; i++)
			{
				rooms.Add(Room.CreateRoom (roomSprite, "Room" + i));
			}
			CreateDoors (rooms);
			Floor.CreateFloor(rooms, "Floor"+floorNum);
		}
		CreateLadders (Floor.floors);
		CreateObjects (Floor.floors);
		Room.CreateExit (new Vector2(0, 200), exitSprite, Floor.floors[Floor.floors.Count-1].rooms[5]);
		Room.GoToRoom(Floor.floors [0].rooms [numFloors/2]);
	}

	void CreateDoors(List<Room> rooms)
	{
		Room lastRoom = null;
		for(int i=0; i<rooms.Count; i++)
		{
			Room nextRoom = rooms[i];
			if(lastRoom != null)
			{
				Room.CreateDoor(new Vector2(200, -80), doorSprite, lastRoom, nextRoom);
				Room.CreateDoor(new Vector2(-200, 210), doorSprite, nextRoom, lastRoom);
			}
			lastRoom = nextRoom;
		}
	}

	void CreateLadders(List<Floor> floors)
	{
		for(int i=1; i<floors.Count; i++)
		{
			int rnd = Random.Range (0, numRoomsPerFloor);
			CreateLadder (floors[i-1], rnd, floors[i], rnd);
		}
	}

	void CreateLadder(Floor floor1, int ladderIndex1, Floor floor2, int ladderIndex2)
	{
		Room.CreateDoor(new Vector2(0, 200), ladderSprite, floor1.rooms[ladderIndex1], floor2.rooms[ladderIndex2]);
		Room.CreateDoor(new Vector2(0, -200), ladderSprite, floor2.rooms[ladderIndex2], floor1.rooms[ladderIndex1]);
	}

	void CreateObjects(List<Floor> floors)
	{
		foreach(Floor floor in floors)
		{
			foreach(Room room in floor.rooms)
			{
				Room.CreateRandomEnemy(new Vector2(0, 0), 50, room);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
