using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{ 
    public Animator animator;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero") || collision.gameObject.CompareTag("Bunny"))
        {
            animator.SetTrigger("PickedUp");

            //The varibale that we are going to modify is static 
            OrbTextScript.OrbAmount += 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(WaitFor(0.6f));
        }
        else
        {
            //Debug.Log("He is not the hero");
        }
    }
    public IEnumerator WaitFor(float seconds)
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(seconds);
        }
        Destroy(this.gameObject);
    }
}
