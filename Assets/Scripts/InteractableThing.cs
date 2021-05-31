using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableThing : MonoBehaviour, IInteractable
{
    public GameObject useButton;
    public Animator anim;
    public bool isInteracting = false;
    void Awake()
	{
        anim = gameObject.GetComponentInParent<Animator>();
        useButton.GetComponent<Button>().onClick.AddListener(Interact);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //isInteracting = anim.GetBool("isPlayerInteract");
        //anim.
    }

    public void Interact()
	{
        if (isInteracting)
            return;
        //print("@");
        //print(anim == null);
        anim.SetTrigger("Interact");
        //anim.SetBool("isPlayerInteract", true);
        //anim.SetBool("isPlayerInteract", false);
    }

    public void SwitchUseButton(bool isActive)
	{
        useButton.GetComponent<Button>().interactable = isActive;
    }
}
