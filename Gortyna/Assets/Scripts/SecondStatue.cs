using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStatue : MonoBehaviour
{
    public MainCharactersManager mainCharactersManager;
    Human human;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            human = collision.GetComponent<Human>();
            mainCharactersManager.CanBird(human);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            Bird bird = collision.GetComponent<Bird>();
            mainCharactersManager.HumanMutationFromBird(bird);
        }
        mainCharactersManager.CanNotBird(human);
    }
}
