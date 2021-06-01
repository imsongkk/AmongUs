using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstManager : MonoBehaviour
{
    private static ConstManager instance;
	public const int TOP_MENU_COUNT = 2;
	public const int CONTROL_COUNT = 2;
	public static Color highlightedColor = new Color(57, 248, 75, 1);
	public static ConstManager Instance
	{
		get
		{
			if (instance == null)
				return null;
			return instance;
		}
	}

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
}
