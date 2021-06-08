using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmongUsRoomManager : NetworkRoomManager
{
	public override void OnRoomServerConnect(NetworkConnection conn)
	{
		base.OnRoomServerConnect(conn);
	}
}
