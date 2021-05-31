using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
	public static GameManager m_instance
	{
		get
		{
			if (instance == null)
				return null;
			return instance;
		}
	}

	public int resolutionX, resolutionY;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		resolutionX = 1920;
		resolutionY = 1080;
	}
}
