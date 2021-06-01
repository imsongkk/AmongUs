using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
	public enum menuState
	{
		GENERAL,
		DATA
	}
	public enum controllState
	{
		MOUSE,
		KEYBOARDMOUSE,
	}
	public static menuState mState = menuState.GENERAL;
	public static menuState fmState = menuState.GENERAL;
	public static controllState cState = controllState.MOUSE;
	public static controllState fcState = controllState.MOUSE;
	public static float EffectSound { get; set; }
	public static float BGMSound { get; set; }
}
