using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBox : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Hit");
            Character c = (collision.gameObject.GetComponent<Human>());
            c.TakeDamage(1);
        }
        else
        {
            Debug.Log("Is something esle" );
        }
    }
}
