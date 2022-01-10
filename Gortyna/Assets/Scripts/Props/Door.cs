using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Human human;
    [HideInInspector] public bool enoughOrbs;

    private void Start()
    {
        enoughOrbs = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Human>())
        {
            human = collision.gameObject.GetComponent<Human>();

            if (OrbTextScript.OrbAmount == 3)
            {
                enoughOrbs = true;
                human.speed = 0;
                human.animator.SetFloat("Speed", 0);
                human.animator.SetTrigger("Death");
                StartCoroutine("DeathCoroutine", human);
            }
            else
            {
                Debug.Log("Not enough orbs");
            }
        }
    }
    public IEnumerator DeathCoroutine(Character c)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(c.gameObject);
    }
}
