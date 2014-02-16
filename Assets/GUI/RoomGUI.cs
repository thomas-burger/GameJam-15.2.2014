using UnityEngine;
using System.Collections;

public class RoomGUI : GUIFrame
{
	public static RoomGUI singleton = null;

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
			GUI.depth = 2;
			if(Room.currentRoom != null)
			{
				Sprite roomSprite = Room.currentRoom.roomSprite;
				screenRect = relativeToScreenSize ? GUIUtil.CalculateScreenRect(frameRect) : frameRect;
				GUI.DrawTexture (screenRect, roomSprite.texture, ScaleMode.ScaleToFit);
			}
		}
	}

	public static Rect GetRoomObjectScreenRect(Room room, RoomObject roomObject)
	{
		Vector2 positionInWorld = new Vector2(roomObject.transform.position.x, roomObject.transform.position.y);
		float scaleX = singleton.screenRect.width / room.roomSprite.textureRect.width;
		float scaleY = singleton.screenRect.height / room.roomSprite.textureRect.height;
		scaleX = scaleY;
		float width = roomObject.sprite.textureRect.width;
		float height = roomObject.sprite.textureRect.height;
		return new Rect ((int)(singleton.screenRect.center.x + scaleX * positionInWorld.x), (int)(singleton.screenRect.center.y + scaleY * positionInWorld.y), (int)(scaleX*width), (int)(scaleY*height));
	}

	public static Rect GetRoomObjectScreenRectCentered(Room room, RoomObject roomObject)
	{
		Vector2 positionInWorld = new Vector2(roomObject.transform.position.x, roomObject.transform.position.y);
		float scaleX = singleton.screenRect.width / room.roomSprite.textureRect.width;
		float scaleY = singleton.screenRect.height / room.roomSprite.textureRect.height;
		scaleX = scaleY;
		float width = roomObject.sprite.textureRect.width;
		float height = roomObject.sprite.textureRect.height;
		return new Rect ((int)(singleton.screenRect.center.x + scaleX * (positionInWorld.x-width/2)),
		                 (int)(singleton.screenRect.center.y + scaleY * (positionInWorld.y-height/2)),
		                 (int)(scaleX*width), (int)(scaleY*height));
	}

	public static Vector2 GetRoomObjectPositionOnScreen(Room room, RoomObject roomObject)
	{
		Vector2 positionInWorld = new Vector2 (roomObject.transform.position.x, roomObject.transform.position.y);
		float scaleX = singleton.screenRect.width / room.roomSprite.textureRect.width;
		float scaleY = singleton.screenRect.height / room.roomSprite.textureRect.height;
		scaleX = scaleY;
		return new Vector2(singleton.screenRect.center.x + scaleX*positionInWorld.x, singleton.screenRect.center.y + scaleY*positionInWorld.y);
	}
}
