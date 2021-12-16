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
            Human human = collision.GetComponent<Human>();
            mainCharactersManager.CanBunny(human);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny"))
        {
            Bunny bunny = collision.GetComponent<Bunny>();
            mainCharactersManager.HumanMutation(bunny);
        }
    }
}
