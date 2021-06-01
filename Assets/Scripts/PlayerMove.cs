﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2f;
    public float playerXSize = 0.36f;
    public float playerYSize = 0.36f;
    public bool isRight = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0), 1f);
        if (!isRight)
            transform.localScale = new Vector3(-playerXSize, playerYSize, 1);
        if(dir.magnitude == 0)
            anim.SetBool("isStopped", true); // -> Idle 재생
        else
            anim.SetBool("isStopped", false); // -> Walk 재생
        if(dir.x > 0)
        {
            if (dir.magnitude != 0)
            {
                transform.localScale = new Vector3(playerXSize, playerYSize, 1);
                isRight = true;
            }
        }
        else if(dir.x < 0)
        {
            transform.localScale = new Vector3(-playerXSize, playerYSize, 1);
            isRight = false;
        }
        transform.position += dir * speed * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        print(collision.gameObject.GetType());
        //InteractableThing target = collision.gameObject.GetComponent<InteractableThing>();
        //print(target == null);
        //InteractableThing target = collision.gameObject;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        
    }
}
