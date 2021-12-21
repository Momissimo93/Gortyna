using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMushroom : MonoBehaviour
{
    Animator animator;
    private float bounce = 15f;
    // Start is called before the first frame update

    private void Start()
    {
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
