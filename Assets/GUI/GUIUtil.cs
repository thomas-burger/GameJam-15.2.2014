using UnityEngine;
using System.Collections;

public class GUIUtil {

	public static readonly float pixelsPerUnit = 100.0f;

	public static Rect CalculateScreenRect(Rect rect)
	{
		return new Rect(rect.x*Screen.width, rect.y*Screen.height, rect.width*Screen.width, rect.height*Screen.height);
	}
}
