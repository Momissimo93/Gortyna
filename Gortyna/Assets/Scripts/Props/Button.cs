using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;
    [HideInInspector] public GameObject gObj;
    private void Awake()
    {
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
        else
            Debug.Log("Error");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny") || collision.gameObject.CompareTag("Hero") || collision.gameObject.CompareTag("Bird"))
        {
            if (gObj.GetComponent<VerticalPlaform>())
            {
                VerticalPlaform verticalPlatform = gObj.GetComponent<VerticalPlaform>();
                animator.SetTrigger("ButtonPressed");
                verticalPlatform.canMove = true;
            }
            else if (gObj.GetComponent<MagicDoor>())
            {
                MagicDoor magicDoor = gObj.GetComponent<MagicDoor>();
                animator.SetTrigger("ButtonPressed");
                magicDoor.OpenDoor();
            }
        }
    }
}
