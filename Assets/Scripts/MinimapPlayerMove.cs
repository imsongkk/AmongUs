using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayerMove : MonoBehaviour
{
    public GameObject map;
    public GameObject player;
    public GameObject minimap;
    private Vector2 mapCenterPos;
    private Vector2 playerPos;
    private Vector2 udPlayerPos; // 맵의 중앙으로부터 얼마만큼의 Unit Distance만큼 떨어져 있는지,
    private Rect minimapRect;

    // Start is called before the first frame update
    void Start()
    {
        mapCenterPos = map.transform.position;
        playerPos = player.transform.position;
        minimapRect = minimap.GetComponent<RectTransform>().rect;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        udPlayerPos = playerPos - mapCenterPos;
        //print(map.GetComponent<SpriteRenderer>().size);
        //print(udPlayerPos); //3.9 2.6
        //print(transform.GetComponent<RectTransform>().position); 
        Vector3 temp = transform.GetComponent<RectTransform>().position;
        //print(temp); // 960, 590
        //print(mapCenterPos); // -0.8, 0.9
        //temp.x += udPlayerPos.x * 100;
        //temp.y += udPlayerPos.y * 100;
        transform.GetComponent<RectTransform>().position = new Vector3(960 + udPlayerPos.x * 100, 590 + udPlayerPos.y * 100, 0f);
        //transform.GetComponent<RectTransform>().position = temp;
    }
}
