using UnityEngine;
using System.Collections;

public class InventoryGUI : GUIFrame {
	public static InventoryGUI singleton = null;
	public CharacterData charData = null;

	// Use this for initialization
	void Start () {
		if(singleton == null)
		{
			singleton = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnGUI()
	{
		if(!hidden)
		{
			base.OnGUI();
			int cursorY = (int)screenRect.y;
			int cursorX = (int)screenRect.x+10;
			GUI.Label(new Rect(cursorX, cursorY, screenRect.width, 50), "Stats");
			cursorY += 20;
			GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "H " + charData.getHealth());
			cursorX+=40;
			GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "E: " + charData.getEnergy());
			cursorX+=40;
			GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "W: " + charData.getWeaponLevel());
			cursorX-=80;
			cursorY+=14;
			var enemy = Room.getEnemy ();
			if (enemy!=null){
				GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "monster: " + enemy.level);
			}
			if(Floor.currentFloor != null)
			{
				cursorY +=18;
				GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100),  Floor.currentFloor.floorName);
			}
			if(Room.currentRoom != null)
			{
				cursorX+=50;
				GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100),  Room.currentRoom.roomName);
			}
		}
	}
}
