using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSustain : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            collision.transform.SetParent(transform);
        }
    }
}
