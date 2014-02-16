using UnityEngine;
using System.Collections;

public class FloorMap : MonoBehaviour {
	public bool mapActive = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DrawRoom(Room room, int xOffset, int yOffset)
	{
		if(room == Room.currentRoom)
		{
			GUI.Button (new Rect(xOffset, yOffset, 50, 50), "X");
		}
		else
		{
			GUI.Button (new Rect(xOffset, yOffset, 50, 50), "");
		}
	}

	void DrawFloor(Floor floor, int yOffset)
	{
		for(int i=0; i<floor.rooms.Count; i++)
		{
			Room room = floor.rooms[i];
			DrawRoom (room, 50*(i+1), yOffset);
		}
	}

	void DrawFloorMap()
	{
		for(int i=0; i<Floor.floors.Count; i++)
		{
			Floor floor = Floor.floors[i];
			DrawFloor(floor, 50*(i+1));
		}
	}

	void OnGUI()
	{
		if(Game.Running)
		{
			if(mapActive)
			{
				if(GUI.Button(new Rect(0, 0, 50, 50), "Map"))
				{
					mapActive = false;
				}
				DrawFloorMap();
			}
			else
			{
				if(GUI.Button(new Rect(0, 0, 50, 50), "Map"))
				{
					mapActive = true;
				}
			}
		}
	}
}
