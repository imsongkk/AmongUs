using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Button> imposterCountButtons;
    [SerializeField]
    private List<Button> maxPlayerCountButtons;

    private CreateGameRoomData roomData;
	private void Start()
	{
        roomData = new CreateGameRoomData();
	}
    public void UpdateImposterCount(int count)
	{
        roomData.imposterCount = count;
        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 7 : 9;
        print(roomData.maxPlayerCount + " " + limitMaxPlayer);
        if (roomData.maxPlayerCount < limitMaxPlayer)
            UpdateMaxPlayerCount(limitMaxPlayer);
        else
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        UpdateImposterImage();
        for(int i=0; i<maxPlayerCountButtons.Count; i++)
		{
            Text text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            if(i<limitMaxPlayer - 4)
			{
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
			}
            else
			{
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.white;
			}
		}
	}
    public void UpdateMaxPlayerCount(int count)
	{
        roomData.maxPlayerCount = count;
        UpdateMaxPlayerImage();
	}
    private void UpdateImposterImage()
	{
        for(int i=0; i<imposterCountButtons.Count; i++)
		{
            if (i == roomData.imposterCount-1)
                imposterCountButtons[i].image.color = Color.white;
            else
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
		}
	}
    private void UpdateMaxPlayerImage()
	{
        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            if (i == roomData.maxPlayerCount - 4)
                maxPlayerCountButtons[i].image.color = Color.white;
            else
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    public void CreateRoom()
	{
        var manager = AmongUsRoomManager.singleton;
        // 방 설정 작업 처리
        //
        //
        manager.StartHost();
	}
}

public class CreateGameRoomData
{
    public int imposterCount { get; set; }
    public int maxPlayerCount { get; set; }
    public CreateGameRoomData()
	{
        imposterCount = ConstManager.defaultImposterCount;
        maxPlayerCount = ConstManager.defaultMaxPlayerCount;
	}
}
