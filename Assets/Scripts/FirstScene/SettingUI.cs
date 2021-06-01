using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
	[SerializeField]
	private Button[] topMenuButton = new Button[ConstManager.TOP_MENU_COUNT];
	[SerializeField]
	private GameObject[] topMenu = new GameObject[ConstManager.TOP_MENU_COUNT];
	[SerializeField]
	private Button[] controlButton = new Button[ConstManager.CONTROL_COUNT];
	[SerializeField]
	private Slider Effect, BGM;
	public Animator anim;

	private void OnEnable()
	{
		UpdateTopButton((int)PlayerSettings.fmState);
		topMenu[(int)PlayerSettings.mState].gameObject.SetActive(true);
		UpdateControlButton((int)PlayerSettings.cState);
		UpdateSoundValue();
	}
	public void UpdateSoundValue()
	{
		PlayerSettings.EffectSound = Effect.value;
		PlayerSettings.BGMSound = BGM.value;
	}
	public void UpdateTopButton(int idx)
	{
		UpdateTopButtonColor(idx);
		UpdateTopMenu(idx);
		PlayerSettings.mState = (PlayerSettings.menuState)idx;
	}
	public void UpdateTopMenu(int idx)
	{
		if (PlayerSettings.mState == (PlayerSettings.menuState)idx)
			return;
		int current = (int)PlayerSettings.mState;
		topMenu[current].gameObject.SetActive(false);
		topMenu[idx].gameObject.SetActive(true);
	}
	public void UpdateControlButton(int idx)
	{
		UpdateControlButtonColor(idx);
		PlayerSettings.cState = (PlayerSettings.controllState)idx;
	}
	private void UpdateTopButtonColor(int idx)
	{
		if (PlayerSettings.mState == (PlayerSettings.menuState)idx) // 선택한 메뉴가 이미 선택되어있으면
		{
			topMenuButton[idx].image.color = Color.green;
			return;
		}
		int current = (int)PlayerSettings.mState;
		topMenuButton[current].image.color = Color.white;
		topMenuButton[idx].image.color = Color.green;
	}
	private void UpdateControlButtonColor(int idx)
	{
		if (PlayerSettings.cState == (PlayerSettings.controllState)idx) // 선택한 메뉴가 이미 선택되어있으면
		{
			controlButton[idx].image.color = Color.green;
			return;
		}
		int current = (int)PlayerSettings.cState;
		controlButton[current].image.color = Color.white;
		controlButton[idx].image.color = Color.green;
	}
}
