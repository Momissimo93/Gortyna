using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStatue : MonoBehaviour
{
    public MainCharactersManager mainCharactersManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            //Destroy(collision.gameObject);
            //SpawnBunny(collision.transform);
            Human human = collision.GetComponent<Human>();
            mainCharactersManager.CanBunny(human);
            Debug.Log("Collision");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny"))
        {
            Debug.Log("Destroy the bunny");
            Bunny bunny = collision.GetComponent<Bunny>();
            mainCharactersManager.HumanMutation(bunny);
        }
    }
}
