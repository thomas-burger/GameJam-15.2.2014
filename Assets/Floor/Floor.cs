using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor
{
	public static Floor currentFloor = null;

	public static List<Floor> floors = new List<Floor> ();

	public string floorName = "";
	public List<Room> rooms = new List<Room>();
	
	public static Floor CreateFloor(List<Room> rooms, string floorName)
	{
		Floor floor = new Floor ();
		floor.rooms = rooms;
		foreach(Room room in rooms)
		{
			room.floor = floor;
		}
		floor.floorName = floorName;
		floors.Add (floor);
		return floor;
	}
}
