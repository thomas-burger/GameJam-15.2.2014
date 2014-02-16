using UnityEngine;
using System.Collections;

public enum DecorType
{
	Table,
	LeftCandle1,
	LeftCandle2,
	Barrels,
	RightCandle,
	Banner,
	Rug
}

public class Decor : RoomObject {

	public DecorType decorType;
	
	public static string TableFileName = "table";
	public static string LeftCandle1FileName = "left_candle";
	public static string LeftCandle2FileName = "left_candle";
	public static string BarrelsFileName = "barrels";
	public static string RightCandleFileName = "right_candle";
	public static string BannerFileName = "banner";
	public static string RugFileName = "rug";

	
	// Use this for initialization
	void Start () {
		friendly = true;
		switch(decorType)
		{
		case DecorType.Table:
		{
			sprite = Resources.Load<Sprite>(TableFileName);
			break;
		}
		case DecorType.LeftCandle1:
		{
			sprite = Resources.Load<Sprite>(LeftCandle1FileName);
			break;
		}
		case DecorType.LeftCandle2:
		{
			sprite = Resources.Load<Sprite>(LeftCandle2FileName);
			break;
		}
		case DecorType.Barrels:
		{
			sprite = Resources.Load<Sprite>(BarrelsFileName);
			break;
		}
		case DecorType.RightCandle:
		{
			sprite = Resources.Load<Sprite>(RightCandleFileName);
			break;
		}
		case DecorType.Banner:
		{
			sprite = Resources.Load<Sprite>(BannerFileName);
			break;
		}
		case DecorType.Rug:
		{
			sprite = Resources.Load<Sprite>(RugFileName);
			break;
		}

		default:
		{
			Debug.Log ("Sprite for decor type " + decorType + " not specified.");
			break;
		}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
