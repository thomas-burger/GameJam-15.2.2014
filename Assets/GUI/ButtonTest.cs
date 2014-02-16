using UnityEngine;
using System.Collections;

public class ButtonTest : MonoBehaviour
{
	public Rect buttonRect1;
	public Rect buttonRect2;

	public CharacterData charData = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button (buttonRect1, "add health point"))
		{
			charData.health +=1;
		}
		if(GUI.Button (buttonRect2, "subtract health point"))
		{
			charData.health -=1;
		}
	}
}
