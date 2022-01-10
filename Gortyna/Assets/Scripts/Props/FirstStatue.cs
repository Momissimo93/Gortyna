using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStatue : MonoBehaviour
{
    [SerializeField] private MainCharactersManager mainCharactersManager;
    Human human;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            human = collision.GetComponent<Human>();
            mainCharactersManager.CanBunny(human);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny"))
        {
            Bunny bunny = collision.GetComponent<Bunny>();
            mainCharactersManager.HumanMutationFromBunny(bunny);
        }
        mainCharactersManager.CanNotBunny(human);
    }
}
