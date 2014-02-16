using UnityEngine;
using System.Collections;

public class LeaveDungeon : MonoBehaviour
{
		public bool mapActive = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void DrawRoom (Room room, int xOffset, int yOffset)
		{
				if (room == Room.currentRoom) {
						GUI.Button (new Rect (xOffset, yOffset, 50, 50), "X");
				} else {
						GUI.Button (new Rect (xOffset, yOffset, 50, 50), "");
				}
		}

		void DrawFloor (Floor floor, int yOffset)
		{
				for (int i=0; i<floor.rooms.Count; i++) {
						Room room = floor.rooms [i];
						DrawRoom (room, 50 * (i + 1), yOffset);
				}
		}

		void DrawFloorMap ()
		{
				for (int i=0; i<Floor.floors.Count; i++) {
						Floor floor = Floor.floors [i];
						DrawFloor (floor, 50 * (i + 1));
				}
		}

		void OnGUI ()
		{
			if (Game.Running) {
				if(GUI.Button (new Rect (51, 0, 75, 50), "Leave")){
					Game.EndGame("You quit.");
				}
			}
		}
}
