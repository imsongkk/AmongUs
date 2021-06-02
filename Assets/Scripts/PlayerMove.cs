using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2f;
    public float playerXSize = 0.36f;
    public float playerYSize = 0.36f;
    public bool isRight = true;
    private Animator anim;
    public GameObject map;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
	private void Move()
	{
        Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0), 1f);
        if (!isRight)
            transform.localScale = new Vector3(-playerXSize, playerYSize, 1);
        if (dir.magnitude == 0)
            anim.SetBool("isStopped", true); // -> Idle 재생
        else
            anim.SetBool("isStopped", false); // -> Walk 재생
        if (dir.x > 0)
        {
            if (dir.magnitude != 0)
            {
                transform.localScale = new Vector3(playerXSize, playerYSize, 1);
                isRight = true;
            }
        }
        else if (dir.x < 0)
        {
            transform.localScale = new Vector3(-playerXSize, playerYSize, 1);
            isRight = false;
        }
        transform.position += dir * speed * Time.deltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{  
        InteractableThing target = collision.gameObject.GetComponent<InteractableThing>();
        print(target.gameObject.name);
        if (target == null)
            print("SAD");
        else
            print("HAPPY");
        target.PlayerEncounter(true);
        target.Interact();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        InteractableThing target = collision.gameObject.GetComponent<InteractableThing>();
        if (target == null)
            return;
        target.PlayerEncounter(false);
    }
}
