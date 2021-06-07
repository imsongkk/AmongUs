using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmongUsRoomManager : NetworkRoomManager
{
	public override void OnRoomServerConnect(NetworkConnection conn)
	{
		print("A");
		base.OnRoomServerConnect(conn);
		var player = Instantiate(spawnPrefabs[0]);
		NetworkServer.Spawn(player, conn);
	}
}
