using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableThing : MonoBehaviour
{
	public IAnim anim;
	public Button useButton;
	abstract public void PerformEvent();
    public void SetActiveUseButton(bool isTrue)
	{
		useButton.interactable = isTrue;
	}
	public void PerformAnim()
	{
		anim.Play();
	}
}

public class Vent : InteractableThing
{
	private void Awake()
	{
		gameObject.AddComponent<AnimVent>();
	}
	public override void PerformEvent() // 유저가 Vent랑 Interact했을 때 실행 되어야 할 이벤트
	{

	}
}
