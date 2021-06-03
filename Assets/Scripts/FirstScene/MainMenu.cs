using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public GameObject settingMenu;
	public Animator anim;

	public void OnPractice()
	{
		SceneManager.LoadScene("MainScene");
	}
	public void OnReturn(GameObject target) // 현재 창 닫기
	{
		StartCoroutine(CloseAfterDelay(target));
	}
	private IEnumerator CloseAfterDelay(GameObject target)
	{
		anim.SetTrigger("Close");
		yield return new WaitForSeconds(0.5f);
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
