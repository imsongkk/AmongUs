using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMover : NetworkBehaviour
{
    public bool isMoveable;

    [SyncVar]
    public float speed = 2f;

    private SpriteRenderer spriteRenderer;

    [SyncVar(hook = nameof(SetPlayerColor_Hook))]
    public EPlayerColor playerColor;
	public bool isRight = true;

    private Animator anim;
    public float playerXSize = 0.5f;
    public float playerYSize = 0.5f;

    //private Vector3 dir = Vector3.zero;
    private Vector3 clickPosition = Vector3.zero;

    public void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
	{
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(newColor));
	}

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));
        if (hasAuthority)
        {
            anim = GetComponent<Animator>();
            Camera cam = Camera.main;
            cam.transform.SetParent(transform);
            cam.transform.localPosition = new Vector3(0f, 0f, -10f);
            cam.orthographicSize = 2.5f;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private bool inRange()
    {
        if (anim.GetBool("isStopped") || Vector3.Distance(clickPosition, new Vector3(transform.position.x, transform.position.y, -10f)) <= 0.01f)
            return true;
        return false;
    }

    public void Move()
	{
		if(hasAuthority && isMoveable)
		{
            if(PlayerSettings.cState == PlayerSettings.controllState.KEYBOARDMOUSE)
			{
                Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);
                if (dir.x < 0f)
                    transform.localScale = new Vector3(-playerXSize, playerYSize, 1f);
                else if (dir.x > 0f)
                    transform.localScale = new Vector3(playerXSize, playerYSize, 1f);
                transform.position += dir * speed * Time.deltaTime;
            }
            else
			{
                if(Input.GetMouseButton(1))
				{
                    Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;
                    if (dir.x < 0f)
                        transform.localScale = new Vector3(-playerXSize, playerYSize, 1f);
                    else if (dir.x > 0f)
                        transform.localScale = new Vector3(playerXSize, playerYSize, 1f);
                    transform.position += dir * speed * Time.deltaTime;
                }
			}
            /*
             * 
            if(inRange())
            {
                print("A");
                anim.SetBool("isStopped", true);
                dir = Vector3.zero;
            }
            if (Input.GetMouseButtonDown(1)) // 마우스 입력이 있다면 
            {
                clickPosition = Input.mousePosition;
                dir = (clickPosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;
                clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
                anim.SetBool("isStopped", false);
            }
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
            if (PlayerSettings.cState == PlayerSettings.controllState.KEYBOARDMOUSE)
			{
				dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);
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
            */
		}
	}
}
