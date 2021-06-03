using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
	private PlayerMove player;
	private void Awake()
	{
		player = GameObject.Find("Player").GetComponent<PlayerMove>();
	}
	private void Update()
	{
		player = GameObject.Find("Player").GetComponent<PlayerMove>();
	}
	public void OnClickUseButton()
	{
		if (player.target != null)
		{
			player.target.Interact();
		}
	}
}
