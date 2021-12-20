using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator animator;
    public VerticalPlaform verticalPlatform;
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
        if (collision.gameObject.CompareTag("Bunny"))
        {
            animator.SetTrigger("ButtonPressed");
            verticalPlatform.canMove = true;
        }
    }
}
