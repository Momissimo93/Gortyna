using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSuspended : MonoBehaviour
{
    [SerializeField] private TrapsAttack trapsAttack;
    int damages = 1;
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
            Human humam = collision.gameObject.GetComponent<Human>();
            trapsAttack.Attack(humam, damages);
        }
    }
}
