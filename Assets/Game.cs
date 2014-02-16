using UnityEngine;
using System.Collections;

public class Game
{
	private static bool running = false;
	public static bool Running{ get { return running; } }

	public static void ShowStartScreen()
	{
		ExitScreen.singleton.Hide ();
		StartScreen.current.Show ();
	}

	public static void StartGame(int randomSeed)
	{
		Debug.Log ("Start game");
		StartScreen.current.Hide ();
		Init.current.InitDungeon(randomSeed);
		InventoryGUI.singleton.Show ();
		CharacterScreen.singleton.Show ();
		//LogGUI.singleton..Show();
		RoomGUI.singleton.Show ();
		CharacterData.singleton.SetClass (CharacterSelectionScreen.singleton.chosen);
		Game.running = true;
	}

	public static void EndGame(string message)
	{
		running = false;
		ExitScreen.singleton.Show (message);
	}
}
