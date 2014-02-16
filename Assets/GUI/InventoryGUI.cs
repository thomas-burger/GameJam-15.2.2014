using UnityEngine;
using System.Collections;

public class InventoryGUI : GUIFrame {
	public static InventoryGUI singleton = null;
	public CharacterData charData = null;

	private Texture2D energyBarTexture = null;

	private Sprite heart = null;

	void Awake()
	{
		energyBarTexture = new Texture2D (1, 1);
		energyBarTexture.SetPixel (0, 0, Color.yellow);
		energyBarTexture.Apply ();
		heart = Resources.Load<Sprite> ("heart");
	}

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
			for(int i=0; i<charData.getHealth (); i++)
			{
				GUI.DrawTexture(new Rect(cursorX+i*20, cursorY, 20, 20), heart.texture);
			}
			cursorY += 30;
			GUI.DrawTexture(new Rect(cursorX, cursorY, screenRect.width*charData.getEnergy()/charData.maxEnergy, 10), energyBarTexture, ScaleMode.StretchToFill);
			cursorY+=20;
			//GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "H " + charData.getHealth());
			//cursorX+=40;
			//GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "E: " + charData.getEnergy());
			//cursorX+=40;
			GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "W: " + charData.getWeaponLevel());
			cursorX+=30;
			GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "WT: " + charData.getWeaponType());
			cursorX-=30;
			cursorY+=14;
			var enemy = Room.getEnemy ();
			if (enemy!=null){
				GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "monster: " + enemy.level);
				cursorY+=20;
				GUI.Label (new Rect (cursorX, cursorY, screenRect.width, 100), "monsterT: " + enemy.enemyType);
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
