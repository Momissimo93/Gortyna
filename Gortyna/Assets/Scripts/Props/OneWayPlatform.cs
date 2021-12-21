using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    GameObject g;
    Human human;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(human != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hero"))
        {
            human = collision.gameObject.GetComponent<Human>();
                Debug.Log("The player is here");
        }
        else
        {
            Debug.Log("Error");
        }
    }

    private IEnumerator DisableCollision()
    {
        PolygonCollider2D platformCollider = GetComponent<PolygonCollider2D>();
        Physics2D.IgnoreCollision(human.boxC2D, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(human.boxC2D, platformCollider, false);
    }
}
