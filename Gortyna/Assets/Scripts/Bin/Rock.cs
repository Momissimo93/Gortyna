using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Human>())
        {
            Human human = collision.gameObject.GetComponent<Human>();
            human.animator.SetBool("Pushing", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Human>())
        {
            Human human = collision.gameObject.GetComponent<Human>();
            human.animator.SetBool("Pushing", false);
        }
    }
}
