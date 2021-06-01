using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private Color highlightedColor = new Color(57, 248, 69, 255);
	public GameObject settingMenu;
	public enum menuState
	{
		GENERAL,
		GRAPHIC,
		DATA
	}
	public menuState mState = menuState.GENERAL;

	private void Update()
	{
		switch(mState)
		{
			case menuState.GENERAL:
				break;
		}
	}
	public void OnSetting()
	{
		settingMenu.SetActive(true);
	}
	public void OnPractice()
	{
		SceneManager.LoadScene("MainScene");
	}
	public void OnReturn(GameObject target) // 현재 창 닫기
	{
		target.SetActive(false);
	}
	public void OnQuit() // 게임 종료
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
