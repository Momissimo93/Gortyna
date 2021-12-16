using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hero") || collision.gameObject.CompareTag("Bunny"))
        {
            animator.SetTrigger("PickedUp");
            StartCoroutine(WaitFor(0.3f));
        }
        else
        {
            Debug.Log("He is not the hero");
        }
    }
    public  IEnumerator WaitFor(float seconds )
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(seconds);
        }
        Destroy(this.gameObject);
    }
}
