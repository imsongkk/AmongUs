using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableThing : MonoBehaviour
{
	private Button useButton;
	private bool isPlayerInArea = false;
	public InteractableThing Action; // 실제 InteractableThing을 상속받는 어떤 행위(게임오브젝트)들이 담긴다.
	private void Awake()
	{
		useButton = GameObject.Find("use").GetComponent<Button>();
	}
	abstract public void Interact();
	public void PlayerEncounter(bool isTrue)
	{
		isPlayerInArea = isTrue;
		SetActiveUseButton(isTrue);
	}
	private void SetActiveUseButton(bool isTrue)
	{
		useButton.interactable = isTrue;
	}
}


/*
public class InteractableThing : MonoBehaviour
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
*/
