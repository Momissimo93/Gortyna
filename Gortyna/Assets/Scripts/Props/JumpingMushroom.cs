using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMushroom : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float bounce = 15f;

    private void Start()
    {
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            if (collision.gameObject.GetComponent<Human>().isOnGround == false)
            {
                collision.gameObject.GetComponent<Human>().rigidBody.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                animator.SetTrigger("MushroomPressed");
            }
        }
    }
}
