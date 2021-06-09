using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoomSettingUI : SettingUI
{
	private CharacterMover player;
    public void ExitGameRoom()
	{
		var manager = AmongUsRoomManager.singleton;
		if (manager.mode == Mirror.NetworkManagerMode.Host) // Exit를 누른게 호스트라면
			manager.StopHost();
		else // 클라이언트라면
			manager.StopClient();
	}

	private void Awake()
	{
		// 당연히 모든 플레이어 가져와서 net id 비교하면 되겠지?
		//var a = FindObjectOfType<AmongUsRoomPlayer>();

		player = AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerCharacter;
		//player = a;
	}
	private void OnEnable()
    {
		player.isMoveable = false;
		UpdateControlButtonColor((int)PlayerSettings.cState);
    }

	private void OnDisable()
	{
		player.isMoveable = true;
	}
}
