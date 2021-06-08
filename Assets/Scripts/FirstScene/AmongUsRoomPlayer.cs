using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmongUsRoomPlayer : NetworkRoomPlayer
{
	[SyncVar]
	public EPlayerColor playerColor;

	public void Start()
	{
		base.Start();
		if(isServer)
		{
			SpawnLobbyPlayerCharacter();
		}
	}
	private void SpawnLobbyPlayerCharacter()
	{
		var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
		EPlayerColor color = EPlayerColor.Red;
		for(int i=0; i<(int)EPlayerColor.Lime; i++)
		{
			bool isFindSameColor = false;
			foreach(var roomPlayer in roomSlots)
			{
				var amongUsRoomPlayer = roomPlayer as AmongUsRoomPlayer;
				if(amongUsRoomPlayer.playerColor == (EPlayerColor)i && roomPlayer.netId != netId)
				{
					isFindSameColor = true;
					break;
				}
			}
			if(!isFindSameColor)
			{
				color = (EPlayerColor)i;
				break;
			}
		}
		playerColor = color;
		Vector3 spawnPos = FindObjectOfType<SpawnPosition>().GetSpawnPosition();
		var player = Instantiate(AmongUsRoomManager.singleton.spawnPrefabs[0], spawnPos, Quaternion.identity).GetComponent<CharacterMover>();
		NetworkServer.Spawn(player.gameObject, connectionToClient);
		player.playerColor = color;
	}
}
