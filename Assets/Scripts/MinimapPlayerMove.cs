using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapPlayerMove : MonoBehaviour
{
	public Transform top, bottom, right, left;
	public Transform player;
	private Vector2 playerPos;
	public Image miniMap;
	public Image miniPlayer;

	private void OnEnable()
	{
		UpdatePos();
	}

	private void Update()
	{
		UpdatePos();
	}

	private void UpdatePos()
	{
		Vector2 area = new Vector2(Vector2.Distance(left.position, right.position), Vector2.Distance(bottom.position, top.position)); // 20.8, 11.6
		Vector2 cPos = new Vector2(Vector2.Distance(left.position, new Vector2(player.transform.position.x, 0f)),
			Vector2.Distance(bottom.position, new Vector2(0f, player.transform.position.y)));
		Vector2 temp = new Vector2(cPos.x / area.x, cPos.y / area.y); // 비율
		miniPlayer.rectTransform.anchoredPosition = new Vector2(miniMap.rectTransform.sizeDelta.x * temp.x, miniMap.rectTransform.sizeDelta.y * temp.y);
	}
}
