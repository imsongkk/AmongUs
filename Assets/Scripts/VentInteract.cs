using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentInteract : InteractableThing
{
	private PlayerMove player;
	private Animator playerAnim;
	private Animator ventAnim;
	private GameObject vent;
	private void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerMove>();
		playerAnim = player.gameObject.GetComponent<Animator>();
	}
	public override void Interact()
	{
		playerAnim.SetTrigger("PlayerUseVent");
		vent = player.targetObject;
		ventAnim = vent.GetComponent<Animator>();
		ventAnim.SetTrigger("PlayerUseVent");
	}
}
