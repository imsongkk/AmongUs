using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnim
{
    void Play();
}

public class AnimVent : MonoBehaviour, IAnim
{
	public void Play()
	{
		print("A");
	}
}
