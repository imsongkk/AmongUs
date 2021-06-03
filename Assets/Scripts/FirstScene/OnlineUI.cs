using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineUI : MonoBehaviour
{
    [SerializeField]
    private InputField input;
    [SerializeField]
    private GameObject createRoomUI;

    public void OnClickCreateRoom()
	{
        if(input.text != "")
		{
            PlayerSettings.nickname = input.text;
            createRoomUI.SetActive(true);
            gameObject.SetActive(false);
		}
        else
		{
            input.GetComponent<Animator>().SetTrigger("WrongNickname");
		}
	}
}
