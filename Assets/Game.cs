using UnityEngine;
using System.Collections;

public class Game
{
	private static bool running = false;
	public static bool Running{ get { return running; } }

	public static int randomSeed = 0;

	public static void ShowStartScreen()
	{
		StartScreen.current.hidden = false;
	}

	public static void StartGame()
	{
		Debug.Log ("Start game");
		StartScreen.current.hidden = true;
		Init.current.InitDungeon(randomSeed);
		InventoryGUI.singleton.hidden = false;
		LogGUI.singleton.hidden = false;
		RoomGUI.singleton.hidden = false;
		Game.running = true;
	}

	public static void EndGame()
	{
		running = false;
		ExitScreen.singleton.hidden = false;
	}
}
