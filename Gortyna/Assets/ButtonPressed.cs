using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    Animator animator;
    bool collider = false;
    BoxCollider2D boxCollider2D;
    public MagicDoor magicDoor; 
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Awake()
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
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Hero"))
        {
            animator.SetTrigger("ButtonPressed");
        }
        magicDoor.OpenDoor();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Hero"))
        {
            animator.SetTrigger("ButtonUnPressed");
        }
        magicDoor.CloseDoor();
    }
}