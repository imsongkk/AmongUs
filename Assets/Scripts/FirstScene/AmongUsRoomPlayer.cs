using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmongUsRoomPlayer : NetworkRoomPlayer
{
	[SyncVar(hook = nameof(SetPlayerColor_Hook))]
	public EPlayerColor playerColor;

	public CharacterMover lobbyPlayerCharacter;

	private static AmongUsRoomPlayer myRoomPlayer;
	public static AmongUsRoomPlayer MyRoomPlayer
	{
		get
		{
			if(myRoomPlayer == null)
			{
				var players = FindObjectsOfType<AmongUsRoomPlayer>();
				foreach(var player in players)
				{
					if(player.hasAuthority)
					{
						myRoomPlayer = player;
					}
				}
			}
			return myRoomPlayer;
		}
	}

	public void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
	{
		LobbyUIManager.Instance.CustomizeUI.UpdateColorButton();
	}

	public void Start()
	{
		base.Start();
		if(isServer)
		{
			SpawnLobbyPlayerCharacter();
		}
	}

	[Command] // Mirror에 있는 애트리뷰트로 클라이언트에서 함수를 호출하면 함수 내부 동작이 서버에서 실행되게끔 해준다.
	public void CmdSetPlayerColor(EPlayerColor color) // 클라이언트에서 서버로 데이터 전송
	{
		playerColor = color;
		lobbyPlayerCharacter.playerColor = color;
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
		var player = Instantiate(AmongUsRoomManager.singleton.spawnPrefabs[0], spawnPos, Quaternion.identity).GetComponent<LobbyCharacterMover>();
		NetworkServer.Spawn(player.gameObject, connectionToClient);
		player.ownerNetId = netId;
		player.playerColor = color;
	}
}
