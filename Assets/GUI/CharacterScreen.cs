using UnityEngine;
using System.Collections;

public class CharacterScreen : GUIFrame {
	public static CharacterScreen singleton = null;
	
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
			GUI.DrawTexture (screenRect, CharacterSelectionScreen.singleton.GetCharacterSprite(CharacterData.singleton.GetClass ()).texture, ScaleMode.ScaleToFit);
		}
	}
}
