using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentInteract : InteractableThing
{
	public void Play()
	{
		print("SSS");
	}
	public override void Interact()
	{
		print("GO HOME");
	}
}
