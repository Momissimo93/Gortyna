using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Human>())
        {
            Human human = collision.gameObject.GetComponent<Human>();
            human.animator.SetBool("Pushing", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Human>())
        {
            Human human = collision.gameObject.GetComponent<Human>();
            human.animator.SetBool("Pushing", false);
        }
    }
}