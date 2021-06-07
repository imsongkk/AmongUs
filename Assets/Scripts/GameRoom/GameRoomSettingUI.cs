using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomSettingUI : SettingUI
{
    public void ExitGameRoom()
	{
		var manager = AmongUsRoomManager.singleton;
		if (manager.mode == Mirror.NetworkManagerMode.Host) // Exit를 누른게 호스트라면
			manager.StopHost();
		else // 클라이언트라면
			manager.StopClient();
	}
    private void OnEnable()
    {
		UpdateControlButtonColor((int)PlayerSettings.cState);
    }
}
