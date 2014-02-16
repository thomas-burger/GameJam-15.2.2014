using UnityEngine;
using System.Collections;

public class CharacterSelectionScreen : GUIFrame
{
	public static CharacterSelectionScreen singleton = null;

	Sprite defaultSprite = null;
	Sprite warriorSprite = null;
	Sprite wizardSprite = null;
	Sprite thiefSprite = null;

	public CharacterClass chosen = CharacterClass.Warrior;

	// Use this for initialization
	void Awake ()
	{
		if(singleton == null)
		{
			singleton = this;
		}
		defaultSprite = Resources.Load<Sprite> ("reaper");
		warriorSprite = Resources.Load<Sprite> ("spider");
		wizardSprite = Resources.Load<Sprite> ("reaper");
		thiefSprite = Resources.Load<Sprite> ("zombie");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show(Rect rect)
	{
		screenRect = rect;
		hidden = false;
	}

	private Sprite GetCharacterSprite(CharacterClass characterClass)
	{
		switch(characterClass)
		{
		case CharacterClass.Warrior:
		{
			return warriorSprite;
		}
		case CharacterClass.Wizard:
		{
			return wizardSprite;
		}
		case CharacterClass.Thief:
		{
			return thiefSprite;
		}
		default:
		{
			Debug.Log("Sprite for character class " + characterClass + " not defined.");
			return defaultSprite;
		}
		}
	}

	private string GetCharacterName(CharacterClass characterClass)
	{
		return characterClass.ToString ();
	}

	public override void OnGUI()
	{
		if(!hidden)
		{
			int numClasses = System.Enum.GetValues(typeof(CharacterClass)).Length;
			//chosen character label
			GUI.Label(new Rect(screenRect.x, screenRect.y, screenRect.width, 20), "Character chosen: " + GetCharacterName(chosen));
			//character buttons
			for(int i=0; i<numClasses; i++)
			{
				Sprite sprite = GetCharacterSprite((CharacterClass)i);
				if(GUI.Button(new Rect(screenRect.x+i*screenRect.width/numClasses, screenRect.y+20, screenRect.width/numClasses, screenRect.height-20), sprite.texture))
				{
					chosen = (CharacterClass)i;
				}
			}
		}
	}
}
