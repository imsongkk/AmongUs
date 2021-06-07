using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMover : NetworkBehaviour
{
    public bool isMoveable;
    [SyncVar]
    public float speed = 2f;

	public void Move()
	{
		if(hasAuthority && isMoveable)
		{
			if(PlayerSettings.cState == PlayerSettings.controllState.KEYBOARDMOUSE)
			{
				Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);
				if(dir.x < 0f)
			}
		}
	}
}
